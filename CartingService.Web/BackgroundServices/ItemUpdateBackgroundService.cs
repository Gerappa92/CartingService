using System.Text;
using System.Text.Json;
using CartingService.BusinessLogic.Handlers;
using CartingService.Web.Messages;
using CartingService.Web.Platform;
using MediatR;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace CartingService.Web.BackgroundServices;

public class ItemUpdateBackgroundService : BackgroundService
{
    private readonly ILogger<ItemUpdateBackgroundService> _logger;
    private readonly ConnectionFactory _connectionFactory;
    private readonly IMediator _mediator;

    public ItemUpdateBackgroundService(ILogger<ItemUpdateBackgroundService> logger, RabbitMqFactory rabbitMqFactory, IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
        _connectionFactory = rabbitMqFactory.Factory;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation("ItemUpdateBackgroundService is starting.");

        using var connection = _connectionFactory.CreateConnection();
        using var channel = connection.CreateModel();
        var consumer = new EventingBasicConsumer(channel);

        consumer.Received += (_, ea) =>
        {
            var body = ea.Body.ToArray();
            var message = Encoding.UTF8.GetString(body);
            _logger.LogInformation("ItemUpdateBackgroundService received message: {Message}", message);
            try
            {
                var itemUpdateMessage = JsonSerializer.Deserialize<ItemUpdateMessage>(message);
                var updateItemRequest = new UpdateItemRequest(itemUpdateMessage.Id, itemUpdateMessage.Name, itemUpdateMessage.Price);
                var updatedCount = _mediator.Send(updateItemRequest, stoppingToken).GetAwaiter().GetResult();
                _logger.LogInformation("Updated Items {Count}", updatedCount);
            }
            catch (JsonException e)
            {
                _logger.LogError(e, "Deserialize ItemUpdateMessage failed");
            }
        };

        channel.BasicConsume(queue: "CatalogService-ItemUpdate-Queue",
            autoAck: true,
            consumer: consumer);

        _logger.LogInformation("ItemUpdateBackgroundService is running.");
        while (!stoppingToken.IsCancellationRequested)
        {
            await Task.Delay(TimeSpan.FromSeconds(10), stoppingToken);

        }
    }
}