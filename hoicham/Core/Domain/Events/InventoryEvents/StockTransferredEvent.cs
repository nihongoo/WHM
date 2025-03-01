namespace hoicham.Core.Domain.Events.InventoryEvents
{
    public class StockTransferredEvent : DomainEvent
    {
        public Guid ProductId { get; }
        public Guid SourceWarehouseId { get; }
        public Guid TargetWarehouseId { get; }
        public int Quantity { get; }

        public StockTransferredEvent(
            Guid productId,
            Guid sourceWarehouseId,
            Guid targetWarehouseId,
            int quantity)
        {
            ProductId = productId;
            SourceWarehouseId = sourceWarehouseId;
            TargetWarehouseId = targetWarehouseId;
            Quantity = quantity;
        }
    }
}
