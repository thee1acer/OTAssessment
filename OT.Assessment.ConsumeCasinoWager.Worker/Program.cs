using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OT.Assessment.ConsumeCasinoWager.Worker.Services;

var builder = Host.CreateApplicationBuilder(args);

builder.Services.AddHostedService<CasinoWagerConsumer>();

builder.Build().Run();
