using System.Text;
using RabbitMQ.Client;

namespace OT.Assessment.ProduceCasinoWager.Worker.Services;

public class CasinoWagerProducer
{
    public async Task SendMessageAsync(string message)
    {
        var factory = new ConnectionFactory()
        {
            HostName = Environment.GetEnvironmentVariable("RABBITMQ_HOST") ?? "localhost",
            Port = int.Parse(Environment.GetEnvironmentVariable("RABBITMQ_PORT") ?? "5672"),
            UserName = Environment.GetEnvironmentVariable("RABBITMQ_USERNAME") ?? "guest",
            Password = Environment.GetEnvironmentVariable("RABBITMQ_PASSWORD") ?? "guest"
        };

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

        Console.WriteLine($" [x] Sent: {message}");
    }
}

