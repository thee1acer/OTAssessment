using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using OT.Assessment.ConsumeCasinoWager.Worker.Services;
using OT.Assessment.Database;
using OT.Assessment.Database.Helpers;
using OT.Assessment.Database.Services;
using Microsoft.EntityFrameworkCore;

var builder = Host.CreateApplicationBuilder(args);


builder.Services.AddOptions<ConnectionString>().BindConfiguration("REFERENCE_DB");

builder.Services.AddDbContext<OTAssessmentContext>((provider, options) =>
{
    var connectionDetails = provider.GetRequiredService<IOptions<ConnectionString>>();
    var connectionString = ConnectionStringBuilder.BuildConnectionString(connectionDetails.Value);

    options.UseSqlServer(connectionString, ops => ops.EnableRetryOnFailure());
});

builder.Services.AddHostedService<CasinoWagerConsumer>();
builder.Services.AddScoped<CasinoWagersService>();

builder.Build().Run();
