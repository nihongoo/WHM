using hoicham.Core.Application.DTOs;
using hoicham.Core.Application.DTOs.StockCountDTOs;
using hoicham.Core.Application.Services;
using hoicham.Core.Domain.Common;
using hoicham.Core.Ports.Input;
using hoicham.Core.Ports.Output.Services;

namespace hoicham.Core.Application.UseCases.Inventory
{
	public class PerformStockCountUseCase
	{
		private readonly IInventoryService _inventoryService;
		private readonly ILoggerService _logger;

		public PerformStockCountUseCase(IInventoryService inventoryService, ILoggerService logger)
		{
			_inventoryService = inventoryService;
			_logger = logger;
		}

		public async Task<Result> ExecuteAsync(StockCountCreateDto request, Guid userId)
		{
			_logger.LogInformation($"Starting PerformStockCount for Product: {request.ProductId}, Warehouse: {request.WarehouseId}");

			// Validate input
			if (request.CountedQuantity < 0)
			{
				_logger.LogWarning("Invalid counted quantity: Counted quantity must not be negative");
				return Result.Failure("Counted quantity must not be negative");
			}

			// Gọi service để thực hiện kiểm kê
			var result = await _inventoryService.PerformStockCountAsync(request, userId);
			if (!result.IsSuccess)
			{
				_logger.LogError(null, $"Failed to perform stock count: {result.Error}");
				return result;
			}

			_logger.LogInformation("PerformStockCount completed successfully");
			return Result.Success();
		}
	}
}