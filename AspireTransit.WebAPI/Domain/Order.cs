using AspireTransit.WebAPI.SeedWork;

namespace AspireTransit.WebAPI.Domain
{
    public class Order : Entity
    {
        public required Guid OrderId { get; init; }
        public required Guid CustomerId { get; init; }
        public required List<string> Items { get; init; }
    }
}
