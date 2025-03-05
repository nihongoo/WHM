using hoicham.Core.Domain.Entities;
using hoicham.Core.Ports.Output.Repositories;
using hoicham.Infrastructure.AppDbContext;
using Microsoft.EntityFrameworkCore;

namespace hoicham.Adapter.Secondary.Repositories
{
	public class InventoryTransactionRepository : Repository<InventoryTransaction>, IInventoryTransactionRepository
	{
		public InventoryTransactionRepository(AppDbContext dbContext) : base(dbContext)
		{
		}

		public async Task<IEnumerable<InventoryTransaction>> GetByProductIdAsync(Guid productId)
		{
			return await _dbContext.Set<InventoryTransaction>()
				.Where(it => it.ProductId == productId)
				.ToListAsync();
		}

		public async Task<IEnumerable<InventoryTransaction>> GetAllByWarehouseIdAsync(Guid warehouseId)
		{
			return await _dbContext.Set<InventoryTransaction>()
				.Where(it => it.WarehouseId == warehouseId)
			.ToListAsync();
		}

		public async Task<IEnumerable<InventoryTransaction>> GetByDateRangeAsync(DateTime start, DateTime end)
		{
			return await _dbContext.Set<InventoryTransaction>()
				.Where(it => it.TransactionDate >= start && it.TransactionDate <= end)
			.ToListAsync();
		}

		public async Task<IReadOnlyList<InventoryTransaction>> GetAllByProductAndWarehouseAsync(Guid productId, Guid warehouseId)
		{
			return await _dbContext.Set<InventoryTransaction>()
				.Where(it => it.ProductId == productId && it.WarehouseId == warehouseId)
				.ToListAsync();
		}
	}
}
