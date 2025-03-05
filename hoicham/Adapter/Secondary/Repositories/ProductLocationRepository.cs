using hoicham.Core.Domain.Entities;
using hoicham.Core.Ports.Output.Repositories;
using hoicham.Infrastructure.AppDbContext;
using Microsoft.EntityFrameworkCore;

namespace hoicham.Adapter.Secondary.Repositories
{
	public class ProductLocationRepository : Repository<ProductLocation>, IProductLocationRepository
	{
		public ProductLocationRepository(AppDbContext dbContext) : base(dbContext)
		{
		}

		public async Task<ProductLocation> GetByProductAndWarehouseAsync(Guid productId, Guid warehouseId)
		{
			return await _dbContext.Set<ProductLocation>()
				.FirstOrDefaultAsync(pl => pl.ProductId == productId && pl.WarehouseId == warehouseId);
		}

		public async Task<IEnumerable<ProductLocation>> GetAllByWarehouseAsync(Guid warehouseId)
		{
			return await _dbContext.Set<ProductLocation>()
				.Where(pl => pl.WarehouseId == warehouseId)
				.ToListAsync();
		}

		public async Task<IEnumerable<ProductLocation>> GetAllByProductAsync(Guid productId)
		{
			return await _dbContext.Set<ProductLocation>()
				.Where(pl => pl.ProductId == productId)
				.ToListAsync();
		}

		public async Task<IEnumerable<ProductLocation>> GetByWarehouseAndZoneAsync(Guid warehouseId, string zone)
		{
			return await _dbContext.Set<ProductLocation>()
				.Where(pl => pl.WarehouseId == warehouseId && pl.Zone == zone)
				.ToListAsync();
		}
	}
}
