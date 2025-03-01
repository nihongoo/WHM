namespace hoicham.Core.Ports.Output.Repositories
{
    public interface IUnitOfWork
    {
        IProductRepository Products { get; }
        IWarehouseRepository Warehouses { get; }
        IInventoryTransactionRepository InventoryTransactions { get; }

        Task<bool> SaveChangesAsync();
        Task BeginTransactionAsync();
        Task CommitAsync();
        Task RollbackAsync();
    }
}
