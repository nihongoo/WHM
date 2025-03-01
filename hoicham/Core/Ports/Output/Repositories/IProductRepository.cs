using hoicham.Core.Domain.Entities;

namespace hoicham.Core.Ports.Output.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<Product> GetByNameAsync(string name);
        Task<IEnumerable<Product>> GetLowStockProductsAsync(int threshold);
        Task<bool> ExistsAsync(string name);
    }
}
