namespace hoicham.Core.Domain.Events.ProductEvents
{
    public class ProductUpdatedEvent : DomainEvent
    {
        public Guid ProductId { get; }
        public decimal OldPrice { get; }
        public decimal NewPrice { get; }

        public ProductUpdatedEvent(
            Guid productId,
            decimal oldPrice,
            decimal newPrice)
        {
            ProductId = productId;
            OldPrice = oldPrice;
            NewPrice = newPrice;
        }
    }
}
