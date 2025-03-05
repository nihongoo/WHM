namespace hoicham.Core.Domain.Events.WarehouseEvents
{
	public class SpaceAllocatedEvent : DomainEvent
	{
		public Guid WarehouseId { get; }
		public Guid ProductId { get; }
		public string Zone { get; }
		public string Aisle { get; }
		public string Rack { get; }
		public string Shelf { get; }
		public string Bin { get; }

		public SpaceAllocatedEvent(Guid warehouseId, Guid productId, string zone, string aisle, string rack, string shelf, string bin)
		{
			WarehouseId = warehouseId;
			ProductId = productId;
			Zone = zone;
			Aisle = aisle;
			Rack = rack;
			Shelf = shelf;
			Bin = bin;
		}
	}
}
