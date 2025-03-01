namespace hoicham.Core.Domain.Events.WarehouseEvents
{
    public class WarehouseCapacityUpdatedEvent : DomainEvent
    {
        public Guid WarehouseId { get; }
        public int OldCapacity { get; }
        public int NewCapacity { get; }

        public WarehouseCapacityUpdatedEvent(
            Guid warehouseId,
            int oldCapacity,
            int newCapacity)
        {
            WarehouseId = warehouseId;
            OldCapacity = oldCapacity;
            NewCapacity = newCapacity;
        }
    }
}
