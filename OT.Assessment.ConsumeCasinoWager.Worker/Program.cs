using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using OT.Assessment.ConsumeCasinoWager.Worker.Services;
using OT.Assessment.Database;
using OT.Assessment.Database.Helpers;
using OT.Assessment.Database.Services;

var builder = Host.CreateApplicationBuilder(args);

builder.Services.AddOptions<ConnectionString>().BindConfiguration("REFERENCE_DB");
builder.Services.AddDbContext<OTAssessmentContext>((provider, options) =>
{
    var connectionDetails = provider.GetRequiredService<IOptions<ConnectionString>>();
    var connectionString = ConnectionStringBuilder.BuildConnectionString(connectionDetails.Value);

    options.UseSqlServer(connectionString, ops => ops.EnableRetryOnFailure());
});

builder.Services.RegisterServices();
builder.Services.AddHostedService<CasinoWagerConsumer>();
builder.Services.AddScoped<CasinoWagersService>();

var worker = builder.Build();

using (var scope = worker.Services.CreateScope())
{
    try
    {
        var services = scope.ServiceProvider;
        var context = services.GetRequiredService<OTAssessmentContext>();

        context.Database.EnsureCreated();
    }

    catch (Exception ex)
    {
        throw new Exception($"Error configuring db with exception: {ex}");
    }
}

worker.Run();
