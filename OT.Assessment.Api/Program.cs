using DotNetEnv;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using OT.Assessment.Database;
using OT.Assessment.Database.Helpers;
using OT.Assessment.ProduceCasinoWager.Worker.Services;
using OT.Assessment.Services;

ThreadPool.SetMinThreads(workerThreads: 500, completionPortThreads: 500);

Env.Load();

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
    options.AddPolicy
    (
        name: "AllowAll",
        builder => builder
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod()
            .WithExposedHeaders("content-disposition")
    )
);

builder.Services.AddOptions<ConnectionString>().BindConfiguration("REFERENCE_DB");
builder.Services.AddDbContext<OTAssessmentContext>((provider, options) =>
{
    var connectionDetails = provider.GetRequiredService<IOptions<ConnectionString>>();
    var connectionString = ConnectionStringBuilder.BuildConnectionString(connectionDetails.Value);

    options.UseSqlServer(connectionString, ops =>
    {
        ops.EnableRetryOnFailure();
        ops.CommandTimeout(int.MaxValue);
        ops.MinBatchSize(int.MaxValue);
        ops.MaxBatchSize(int.MaxValue);
    });
});

builder.Services.Configure<KestrelServerOptions>(options =>
{
    options.Limits.MaxConcurrentConnections = 100_000;
    options.Limits.MaxConcurrentUpgradedConnections = 100_000;
    options.Limits.MaxRequestBodySize = 1000  * 10 * 1024;
    options.Limits.KeepAliveTimeout = TimeSpan.FromSeconds(30);
    options.Limits.RequestHeadersTimeout = TimeSpan.FromSeconds(15);
});

builder.Services.RegisterServices();
builder.Services.AddTransient<PlayerService>();
builder.Services.AddSingleton<CasinoWagerProducer>();

builder.Services.AddHealthChecks();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

using (var scope = app.Services.CreateScope())
{
    try
    {
        var services = scope.ServiceProvider;
        var context = services.GetRequiredService<OTAssessmentContext>();
        
        context.Database.EnsureDeleted();
        context.Database.Migrate();
    }

    catch(Exception ex)
    {
        throw new Exception($"Error configuring db with exception: {ex}");
    }
}

app.UseCors("AllowAll");
app.UseAuthorization();
app.MapControllers();
app.MapHealthChecks("/health");

app.Run("http://0.0.0.0:5000");