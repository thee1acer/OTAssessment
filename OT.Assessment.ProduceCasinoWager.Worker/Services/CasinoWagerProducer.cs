using System.Text;
using RabbitMQ.Client;
using DotNetEnv;
using Microsoft.Extensions.Logging;


namespace OT.Assessment.ProduceCasinoWager.Worker.Services;

public class CasinoWagerProducer
{
    private ILogger<CasinoWagerProducer> _logger;

    public CasinoWagerProducer(ILogger<CasinoWagerProducer> logger)
    {
        _logger = logger;
    }

    public async Task SendMessageAsync(string message)
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

            var body = Encoding.UTF8.GetBytes(message);

            await channel.BasicPublishAsync(
                exchange: "",
                routingKey: "my-queue",
                mandatory: true,
                basicProperties: new BasicProperties(),
                body: body
            );

            _logger.LogDebug($"[#] Sent message [#] {DateTime.Now}");
        }
        catch(Exception ex)
        {
            _logger.LogError($"Failed to produce to RabbitQ with exception: {ex}");
        }
    }
}

