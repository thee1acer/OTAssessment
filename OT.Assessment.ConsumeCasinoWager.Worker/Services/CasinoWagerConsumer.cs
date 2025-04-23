using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Microsoft.Extensions.Hosting;
using DotNetEnv;
using OT.Assessment.Database.Services;
using System.Text.Json;
using OT.Assessment.Database.Models;

namespace OT.Assessment.ConsumeCasinoWager.Worker.Services;

public class CasinoWagerConsumer : BackgroundService
{
    private CasinoWagersService _casinoWagersService;

    public CasinoWagerConsumer(CasinoWagersService casinoWagersService)
    {
        _casinoWagersService = casinoWagersService;
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

                var wagers = JsonSerializer.Deserialize<List<Wager>>(message);

                if (wagers?.Any() ?? false)
                {
                    await _casinoWagersService.InsertCasinoWagersAsync(wagers);

                    Console.WriteLine($"[#] Received: {DateTime.Now} [#]");
                    await Task.CompletedTask;
                }
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
            throw new Exception($"Failed to consume with error: {ex}");
        }
    }
}
