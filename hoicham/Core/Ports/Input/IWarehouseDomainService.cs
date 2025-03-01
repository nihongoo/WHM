using hoicham.Core.Domain.Common;

namespace hoicham.Core.Ports.Input
{
    public interface IWarehouseDomainService
    {
        Task<Result> AllocateSpaceAsync(Guid warehouseId, Guid productId, int quantity);
        Task<Result> OptimizeStorageAsync(Guid warehouseId);
    }
}
