namespace AspireTransit.Contracts.Order
{
    public record OrderCreated
    {
        public required Guid OrderId { get; init; }
        public required Guid CustomerId { get; init; }
        public required List<string> Items { get; init; }
    }
}
