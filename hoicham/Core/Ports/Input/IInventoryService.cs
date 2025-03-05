using hoicham.Core.Application.DTOs.InventoryTransactionDTOs;
using hoicham.Core.Application.DTOs.StockCountDTOs;
using hoicham.Core.Domain.Common;
namespace hoicham.Core.Ports.Input
{
    public interface IInventoryService
    {
        Task<bool> CheckStockAvailabilityAsync(Guid productId, int quantity);
        Task<Result> AdjustStockAsync(Guid productId, int quantity, string reason, Guid warehouseId);
        Task<Result> TransferStockAsync(Guid sourceWarehouseId, Guid targetWarehouseId, Guid productId, int quantity);
		Task<Result> CreateInventoryTransactionAsync(InventoryTransactionCreateDto request, Guid userId);
		Task<Result> PerformStockCountAsync(StockCountCreateDto request, Guid userId);
	}
}
