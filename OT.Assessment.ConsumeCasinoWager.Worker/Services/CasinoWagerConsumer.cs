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

namespace OT.Assessment.ConsumeCasinoWager.Worker.Services;

public class CasinoWagerConsumer : BackgroundService
{
    private OTAssessmentContext _dbContext;
    private CasinoWagersService _casinoWagersService;
    private ILogger<CasinoWagerConsumer> _logger;


    public CasinoWagerConsumer(OTAssessmentContext dbContext, CasinoWagersService casinoWagersService, ILogger<CasinoWagerConsumer> logger)
    {
        _dbContext = dbContext;
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
            await using var connection = await factory.CreateConnectionAsync();
            await using var channel = await connection.CreateChannelAsync();

            await channel.QueueDeclareAsync
            (
                queue: "my-queue",
                durable: false,
                exclusive: false,
                autoDelete: false,
                arguments: null
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
                    //await _casinoWagersService.InsertCasinoWagersAsync(wagersMapped);
                    PerformDbInsert();

                    _logger.LogDebug($"[#] Received: {DateTime.Now} [#]");

                    await Task.CompletedTask;
                }
                
                _logger.LogDebug($"[#] Received a empty strying [#]");
            };

            await channel.BasicConsumeAsync
            (
                queue: "my-queue",
                autoAck: true,
                consumer: consumer
            );

            await Task.Delay(Timeout.Infinite, stoppingToken);
        }
        catch(Exception ex)
        {
            _logger.LogError($"Failed to consume with error: {ex}");
        }
    }

    private async void PerformDbInsert()
    {
        try
        {
            var acccount = await _dbContext.Accounts.ToListAsync();

            var wagers = await _dbContext.Wagers.ToListAsync();

            var accountIds = wagers?.Select(v => v.AccountId).ToList();
        }

        catch(Exception e)
        {
            _logger.LogError($"Issue performing db insert {e}");
        }
    }
}
