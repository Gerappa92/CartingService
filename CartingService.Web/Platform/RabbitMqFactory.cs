using CartingService.Web.Options;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;

namespace CartingService.Web.Platform;

public class RabbitMqFactory
{
    public ConnectionFactory Factory { get; }

    public RabbitMqFactory(IOptions<RabbitMqOptions> rabbitMqOptions)
    {
        var options = rabbitMqOptions?.Value ?? throw new ArgumentNullException(nameof(rabbitMqOptions));
        Factory = new ConnectionFactory
        {
            HostName = options.HostName,
            Port = 5672
        };
    }
}