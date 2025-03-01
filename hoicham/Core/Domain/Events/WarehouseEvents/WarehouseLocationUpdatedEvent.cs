namespace hoicham.Core.Domain.Events.WarehouseEvents
{
    public class WarehouseLocationUpdatedEvent : DomainEvent
    {
        public Guid WarehouseId { get; }
        public string OldLocation { get; }
        public string NewLocation { get; }

        public WarehouseLocationUpdatedEvent(
            Guid warehouseId,
            string oldLocation,
            string newLocation)
        {
            WarehouseId = warehouseId;
            OldLocation = oldLocation;
            NewLocation = newLocation;
        }
    }
}
