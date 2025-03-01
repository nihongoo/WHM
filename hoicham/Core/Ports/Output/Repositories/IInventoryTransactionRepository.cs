using hoicham.Core.Domain.Entities;

namespace hoicham.Core.Ports.Output.Repositories
{
    public interface IInventoryTransactionRepository : IRepository<InventoryTransaction>
    {
        Task<IEnumerable<InventoryTransaction>> GetByProductIdAsync(Guid productId);
        Task<IEnumerable<InventoryTransaction>> GetAllByWarehouseIdAsync(Guid warehouseId);
        Task<IEnumerable<InventoryTransaction>> GetByDateRangeAsync(DateTime start, DateTime end);
		Task<IReadOnlyList<InventoryTransaction>> GetAllByProductAndWarehouseAsync(Guid productId, Guid warehouseId);
	}
}
