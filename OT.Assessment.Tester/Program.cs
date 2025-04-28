using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OT.Assessment.Tester.Services;

var builder = Host.CreateApplicationBuilder(args);

builder.Services.AddScoped<CasinoWagerBogusGenerator>();
builder.Services.AddHostedService<NbomberService>();

builder.Build().Run();
