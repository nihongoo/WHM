namespace hoicham.Core.Domain.Events.ProductEvents
{
    public class ProductDeletedEvent : DomainEvent
    {
        public Guid ProductId { get; }
        public string Name { get; }

        public ProductDeletedEvent(Guid productId, string name)
        {
            ProductId = productId;
            Name = name;
        }
    }
}
