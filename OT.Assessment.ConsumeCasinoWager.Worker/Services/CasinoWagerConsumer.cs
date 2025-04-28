using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Microsoft.Extensions.Hosting;
using DotNetEnv;
using OT.Assessment.Database.Services;
using System.Text.Json;
using OT.Assessment.Database.Models;
using Microsoft.Extensions.Logging;
using OT.Assessment.Api.Models;
using Mapster;
using OT.Assessment.Database;
using Microsoft.EntityFrameworkCore;
using OT.Assessment.Services;
using Microsoft.Extensions.DependencyInjection;

namespace OT.Assessment.ConsumeCasinoWager.Worker.Services;

public class CasinoWagerConsumer : BackgroundService
{
    private IServiceProvider _serviceProvider;
    private CasinoWagersService _casinoWagersService;
    private ILogger<CasinoWagerConsumer> _logger;


    public CasinoWagerConsumer(IServiceProvider serviceProvider, CasinoWagersService casinoWagersService, ILogger<CasinoWagerConsumer> logger)
    {
        _serviceProvider = serviceProvider;
        _casinoWagersService = casinoWagersService;
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        Env.Load();

        var factory = new ConnectionFactory()
        {
            HostName = Environment.GetEnvironmentVariable("RABBITMQ_HOST")!,
            Port = int.Parse(Environment.GetEnvironmentVariable("RABBITMQ_PORT")!),
            UserName = Environment.GetEnvironmentVariable("RABBITMQ_USERNAME")!,
            Password = Environment.GetEnvironmentVariable("RABBITMQ_PASSWORD")!,
        };

        try
        {
            await using var connection = await factory.CreateConnectionAsync(stoppingToken);
            await using var channel = await connection.CreateChannelAsync(cancellationToken: stoppingToken);

            await channel.QueueDeclareAsync
            (
                queue: "my-queue",
                durable: false,
                exclusive: false,
                autoDelete: false,
                arguments: null,
                cancellationToken: stoppingToken
            );

            var consumer = new AsyncEventingBasicConsumer(channel);

            consumer.ReceivedAsync += async (sender, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);

                var wagers = JsonSerializer.Deserialize<List<WagerDTO>>(message);
                var wagersMapped = wagers.Adapt<List<Wager>>().ToList();

                if (wagers?.Any() ?? false)
                {
                    PerformDbInsert(wagersMapped);

                    _logger.LogDebug($"[#] Received: {DateTime.Now} [#]");

                    await Task.CompletedTask;
                }
                
                _logger.LogDebug($"[#] Received a empty strying [#]");
            };

            await channel.BasicConsumeAsync
            (
                queue: "my-queue",
                autoAck: true,
                consumer: consumer,
                cancellationToken: stoppingToken
            );

            await Task.Delay(Timeout.Infinite, stoppingToken);
        }
        catch(Exception ex)
        {
            _logger.LogError($"Failed to consume with error: {ex}");
        }
    }

    private async void PerformDbInsert(List<Wager> wagersMapped)
    {
        try
        {
            await _casinoWagersService.InsertCasinoWagersAsync(wagersMapped);
            
            _logger.LogInformation("[x] Performing DB Insert [x]");
        }

        catch(Exception e)
        {
            _logger.LogError($"Issue performing db insert {e}");
        }
    }
}
