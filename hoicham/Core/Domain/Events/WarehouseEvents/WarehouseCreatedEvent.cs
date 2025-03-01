namespace hoicham.Core.Domain.Events.WarehouseEvents
{
    public class WarehouseCreatedEvent : DomainEvent
    {
        public Guid WarehouseId { get; }
        public string Name { get; }
        public string Location { get; }
        public int Capacity { get; }

        public WarehouseCreatedEvent(
            Guid warehouseId,
            string name,
            string location,
            int capacity)
        {
            WarehouseId = warehouseId;
            Name = name;
            Location = location;
            Capacity = capacity;
        }
    }
}
