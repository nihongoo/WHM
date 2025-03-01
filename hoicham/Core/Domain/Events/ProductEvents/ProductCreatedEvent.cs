using hoicham.Core.Domain.Entities;

namespace hoicham.Core.Domain.Events.ProductEvents
{
    public class ProductCreatedEvent : DomainEvent
    {
        public Guid ProductId { get; }
        public string Name { get; }
        public decimal Price { get; }

        public ProductCreatedEvent(Guid productId, string name, decimal price)
        {
            ProductId = productId;
            Name = name;
            Price = price;
        }
    }
}
