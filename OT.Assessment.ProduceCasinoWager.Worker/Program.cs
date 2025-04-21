using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OT.Assessment.ProduceCasinoWager.Worker.Services;

var builder = Host.CreateApplicationBuilder(args);

builder.Services.AddSingleton<CasinoWagerProducer>();

builder.Build().Run();
