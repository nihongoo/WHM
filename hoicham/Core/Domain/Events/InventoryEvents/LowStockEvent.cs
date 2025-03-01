namespace hoicham.Core.Domain.Events.InventoryEvents
{
    public class LowStockEvent : DomainEvent
    {
        public Guid ProductId { get; }
        public int CurrentStock { get; }
        public int Threshold { get; }
        public Guid WarehouseId { get; }

        public LowStockEvent(
            Guid productId,
            int currentStock,
            int threshold,
            Guid warehouseId)
        {
            ProductId = productId;
            CurrentStock = currentStock;
            Threshold = threshold;
            WarehouseId = warehouseId;
        }
    }
}
