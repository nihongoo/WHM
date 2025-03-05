using hoicham.Core.Ports.Output.Repositories;
using hoicham.Infrastructure.AppDbContext;

namespace hoicham.Adapter.Secondary.Repositories
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly AppDbContext _dbContext;
		private IProductRepository _productRepository;
		private IWarehouseRepository _warehouseRepository;
		private IInventoryTransactionRepository _inventoryTransactionRepository;
		private Microsoft.EntityFrameworkCore.Storage.IDbContextTransaction _transaction;

		public UnitOfWork(AppDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public IProductRepository Products => _productRepository ??= new ProductRepository(_dbContext);

		public IWarehouseRepository Warehouses => _warehouseRepository ??= new WarehouseRepository(_dbContext);

		public IInventoryTransactionRepository InventoryTransactions => _inventoryTransactionRepository ??= new InventoryTransactionRepository(_dbContext);

		public async Task<bool> SaveChangesAsync()
		{
			return await _dbContext.SaveChangesAsync() > 0;
		}

		public async Task BeginTransactionAsync()
		{
			_transaction = await _dbContext.Database.BeginTransactionAsync();
		}

		public async Task CommitAsync()
		{
			try
			{
				await _transaction.CommitAsync();
			}
			finally
			{
				await _transaction.DisposeAsync();
			}
		}

		public async Task RollbackAsync()
		{
			try
			{
				await _transaction.RollbackAsync();
			}
			finally
			{
				await _transaction.DisposeAsync();
			}
		}
	}
}
