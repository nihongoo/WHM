using hoicham.Core.Domain.Entities;
using hoicham.Core.Ports.Output.Repositories;
using hoicham.Infrastructure.AppDbContext;
using Microsoft.EntityFrameworkCore;

namespace hoicham.Adapter.Secondary.Repositories
{
	public class WarehouseRepository : Repository<Warehouse>, IWarehouseRepository
	{
		public WarehouseRepository(AppDbContext dbContext) : base(dbContext)
		{
		}

		public async Task<IEnumerable<Product>> GetProductsInWarehouseAsync(Guid warehouseId)
		{
			// Lấy danh sách ProductId từ ProductLocations
			var productIds = await _dbContext.ProductLocations
				.Where(pl => pl.WarehouseId == warehouseId)
				.Select(pl => pl.ProductId)
				.Distinct()
				.ToListAsync();

			// Lấy thông tin chi tiết của các Products
			return await _dbContext.Products
				.Where(p => productIds.Contains(p.Id))
				.ToListAsync();
		}

		public async Task<int> GetTotalStockAsync(Guid productId)
		{
			// Tính tổng số lượng sản phẩm từ các giao dịch inventory
			return await _dbContext.InventoryTransactions
				.Where(it => it.ProductId == productId)
				.SumAsync(it => it.Quantity);
		}
	}
}
