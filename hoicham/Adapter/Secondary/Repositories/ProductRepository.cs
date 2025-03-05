using hoicham.Core.Domain.Entities;
using hoicham.Core.Ports.Output.Repositories;
using hoicham.Infrastructure.AppDbContext;
using Microsoft.EntityFrameworkCore;

namespace hoicham.Adapter.Secondary.Repositories
{
	public class ProductRepository : Repository<Product>, IProductRepository
	{
		public ProductRepository(AppDbContext dbContext) : base(dbContext)
		{
		}

		public async Task<Product> GetByNameAsync(string name)
		{
			return await _dbContext.Products
				.FirstOrDefaultAsync(p => p.Name == name);
		}

		public async Task<IEnumerable<Product>> GetLowStockProductsAsync(int threshold)
		{
			// Dựa vào ERD, Product không có trường TotalStock
			// Thay vào đó, chúng ta sẽ tính tổng số lượng từ InventoryTransactions
			var products = await _dbContext.Products.ToListAsync();
			var result = new List<Product>();

			foreach (var product in products)
			{
				// Tính tổng số lượng từ các giao dịch
				var totalStock = await _dbContext.InventoryTransactions
					.Where(it => it.ProductId == product.Id)
					.SumAsync(it => it.Quantity);

				if (totalStock < threshold)
				{
					result.Add(product);
				}
			}

			return result;
		}

		public async Task<bool> ExistsAsync(string name)
		{
			return await _dbContext.Products
				.AnyAsync(p => p.Name == name);
		}
	}
}
