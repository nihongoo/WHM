using hoicham.Core.Domain.Entities;

namespace hoicham.Core.Ports.Output.Repositories
{
	public interface IProductLocationRepository : IRepository<ProductLocation>
	{
		Task<ProductLocation> GetByProductAndWarehouseAsync(Guid productId, Guid warehouseId);
		Task<IEnumerable<ProductLocation>> GetAllByWarehouseAsync(Guid warehouseId);
		Task<IEnumerable<ProductLocation>> GetAllByProductAsync(Guid productId);
		Task<IEnumerable<ProductLocation>> GetByWarehouseAndZoneAsync(Guid warehouseId, string zone);
		Task<bool> IsLocationOccupiedAsync(Guid warehouseId, string zone, string aisle, string rack, string shelf, string bin);
	}
}
