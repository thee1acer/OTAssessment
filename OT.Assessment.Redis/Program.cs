using DotNetEnv;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using OT.Assessment.Redis.Interfaces;

var builder = Host.CreateDefaultBuilder(args);

builder.ConfigureServices((hostContext, services) =>
{
    Env.Load();

    services.AddStackExchangeRedisCache(options =>
    {
        var redisHost = Environment.GetEnvironmentVariable("REDIS_HOST");
        var redisPort = Environment.GetEnvironmentVariable("REDIS_PORT");
        var redisUsername = Environment.GetEnvironmentVariable("REDIS_USERNAME");
        var redisPassword = Environment.GetEnvironmentVariable("REDIS_PASSWORD");

        var configuration = $"{redisHost}:{redisPort}";

        if (!string.IsNullOrEmpty(redisUsername) && !string.IsNullOrEmpty(redisPassword))
        {
            configuration = $"{redisUsername}:{redisPassword}@{configuration}";
        }

        options.Configuration = configuration;
        options.InstanceName = "OTAssessment:";
    });
    
    services.AddScoped<IRedisService, RedisService>();
    //services.AddHostedService<RedisWorkerService>();
});

await builder.Build().RunAsync();
