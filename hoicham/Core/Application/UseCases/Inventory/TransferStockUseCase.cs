using hoicham.Core.Application.DTOs;
using hoicham.Core.Application.Services;
using hoicham.Core.Domain.Common;
using hoicham.Core.Ports.Input;
using hoicham.Core.Ports.Output.Services;

namespace hoicham.Core.Application.UseCases.Inventory
{
	public class TransferStockUseCase    //Chuyển hàng giữa các kho.
	{
		private readonly IInventoryService _inventoryService;
		private readonly ILoggerService _logger;

		public TransferStockUseCase(IInventoryService inventoryService, ILoggerService logger)
		{
			_inventoryService = inventoryService;
			_logger = logger;
		}

		public async Task<Result> ExecuteAsync(Guid sourceWarehouseId, Guid targetWarehouseId, Guid productId, int quantity)
		{
			_logger.LogInformation($"Starting TransferStock for Product: {productId}, From: {sourceWarehouseId}, To: {targetWarehouseId}, Quantity: {quantity}");

			// Validate input
			if (quantity <= 0)
			{
				_logger.LogWarning("Invalid quantity: Quantity must be positive");
				return Result.Failure("Quantity must be positive");
			}

			// Gọi service để chuyển hàng
			var result = await _inventoryService.TransferStockAsync(sourceWarehouseId, targetWarehouseId, productId, quantity);
			if (!result.IsSuccess)
			{
				_logger.LogError(null, $"Failed to transfer stock: {result.Error}");
				return result;
			}

			_logger.LogInformation("TransferStock completed successfully");
			return Result.Success();
		}
	}
}