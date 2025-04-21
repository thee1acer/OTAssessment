using DotNetEnv;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis; 
using OT.Assessment.Redis.Interfaces;

var builder = Host.CreateDefaultBuilder(args);

builder.ConfigureServices((hostContext, services) =>
{
    Env.Load();

    var redisHost = Environment.GetEnvironmentVariable("REDIS_HOST");
    var redisPort = Environment.GetEnvironmentVariable("REDIS_PORT");
    var redisUsername = Environment.GetEnvironmentVariable("REDIS_USERNAME");
    var redisPassword = Environment.GetEnvironmentVariable("REDIS_PASSWORD");

    services.AddStackExchangeRedisCache(options =>
    {
        var configOptions = new ConfigurationOptions
        {
            EndPoints = { $"{redisHost}:{redisPort}" },
            User = redisUsername,
            Password = redisPassword,
            Ssl = false, 
            AbortOnConnectFail = false
        };

        options.ConfigurationOptions = configOptions;
        options.InstanceName = "OTAssessment:";
    });

    services.AddScoped<IRedisService, RedisService>();
});

await builder.Build().RunAsync();
