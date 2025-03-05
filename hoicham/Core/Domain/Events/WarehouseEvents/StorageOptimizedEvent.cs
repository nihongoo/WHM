namespace hoicham.Core.Domain.Events.WarehouseEvents
{
	public class StorageOptimizedEvent : DomainEvent
	{
		public Guid WarehouseId { get; }

		public StorageOptimizedEvent(Guid warehouseId)
		{
			WarehouseId = warehouseId;
		}
	}
}
