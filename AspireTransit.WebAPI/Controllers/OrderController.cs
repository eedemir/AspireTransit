using AspireTransit.Contracts.Order;
using AspireTransit.WebAPI.Domain;
using MassTransit;
using Microsoft.AspNetCore.Mvc;

namespace AspireTransit.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        readonly IPublishEndpoint _publishEndpoint;

        public OrderController(IPublishEndpoint publishEndpoint)
        {
            _publishEndpoint = publishEndpoint;
        }

        // POST api/<OrderController>
        [HttpPost]
        public async Task<IActionResult> CreateOrder(Order order)
        {
            await _publishEndpoint.Publish<OrderCreated>(new 
            {
                OrderId = order.OrderId,
                CustomerId = order.CustomerId,
                Items = order.Items
            });

            return Ok($"Order created at {DateTime.UtcNow} with ID:{order.OrderId}");
        }
    }
}
