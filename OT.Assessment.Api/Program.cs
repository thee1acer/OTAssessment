using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using OT.Assessment.Database;
using OT.Assessment.Database.Helpers;
using OT.Assessment.ProduceCasinoWager.Worker.Services;
using OT.Assessment.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

builder.Services.AddOptions<ConnectionString>().BindConfiguration("REFERENCE_DB");

builder.Services.AddDbContext<OTAssessmentContext>((provider, options) =>
{
    var connectionDetails = provider.GetRequiredService<IOptions<ConnectionString>>();
    var connectionString = ConnectionStringBuilder.BuildConnectionString(connectionDetails.Value);

    options.UseSqlServer(connectionString, ops => ops.EnableRetryOnFailure());
});

builder.Services.AddTransient<PlayerService>();
builder.Services.AddSingleton<CasinoWagerProducer>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<OTAssessmentContext>();

    context.Database.EnsureDeleted();
    context.Database.Migrate();
}

app.UseCors("AllowAll");
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
