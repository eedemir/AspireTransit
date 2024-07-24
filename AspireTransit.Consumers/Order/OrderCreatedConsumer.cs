using AspireTransit.Contracts.Order;
using MassTransit;
using Microsoft.Extensions.Logging;

namespace AspireTransit.Consumers.Order
{
    public class OrderCreatedConsumer : IConsumer<OrderCreated>
    {
        readonly ILogger<OrderCreatedConsumer> _logger;

        public OrderCreatedConsumer(ILogger<OrderCreatedConsumer> logger)
        {
            _logger = logger;
        }
        public Task Consume(ConsumeContext<OrderCreated> context)
        {
            _logger.LogInformation("Order created with ID: {OrderId}", context.Message.OrderId);
            return Task.CompletedTask;
        }
    }
}
