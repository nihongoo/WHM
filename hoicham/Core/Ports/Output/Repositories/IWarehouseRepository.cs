using hoicham.Core.Domain.Entities;

namespace hoicham.Core.Ports.Output.Repositories
{
    public interface IWarehouseRepository : IRepository<Warehouse>
    {
        Task<IEnumerable<Product>> GetProductsInWarehouseAsync(Guid warehouseId);
        Task<int> GetTotalStockAsync(Guid productId);
    }
}
