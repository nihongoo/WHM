namespace hoicham.Core.Domain.Events.InventoryEvents
{
    public class StockUpdatedEvent : DomainEvent
    {
        public Guid ProductId { get; }
        public int OldQuantity { get; }
        public int NewQuantity { get; }
        public string Reason { get; }
        public Guid? WarehouseId { get; }

        public StockUpdatedEvent(
            Guid productId,
            int oldQuantity,
            int newQuantity,
            string reason,
            Guid? warehouseId = null)
        {
            ProductId = productId;
            OldQuantity = oldQuantity;
            NewQuantity = newQuantity;
            Reason = reason;
            WarehouseId = warehouseId;
        }
    }
}
