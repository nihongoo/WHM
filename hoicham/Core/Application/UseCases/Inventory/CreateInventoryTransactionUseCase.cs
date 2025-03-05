using hoicham.Core.Application.DTOs;
using hoicham.Core.Application.DTOs.InventoryTransactionDTOs;
using hoicham.Core.Application.Services;
using hoicham.Core.Domain.Common;
using hoicham.Core.Ports.Input;
using hoicham.Core.Ports.Output.Services;

namespace hoicham.Core.Application.UseCases.Inventory
{
	public class CreateInventoryTransactionUseCase    //Tạo 1 giao dịch tồn kho
	{
		private readonly IInventoryService _inventoryService;
		private readonly ILoggerService _logger;

		public CreateInventoryTransactionUseCase(IInventoryService inventoryService, ILoggerService logger)
		{
			_inventoryService = inventoryService;
			_logger = logger;
		}

		public async Task<Result> ExecuteAsync(InventoryTransactionCreateDto request, Guid userId)
		{
			_logger.LogInformation($"Starting CreateInventoryTransaction for Product: {request.ProductId}, Warehouse: {request.WarehouseId}, Type: {request.TransactionType}");

			// Validate input
			if (request.Quantity == 0)
			{
				_logger.LogWarning("Invalid quantity: Quantity must not be 0");
				return Result.Failure("Quantity must not be 0");
			}

			if (string.IsNullOrWhiteSpace(request.TransactionType))
			{
				_logger.LogWarning("Invalid transaction type: Transaction type must not be empty");
				return Result.Failure("Transaction type must not be empty");
			}

			// Gọi service để tạo giao dịch
			var result = await _inventoryService.CreateInventoryTransactionAsync(request, userId);
			if (!result.IsSuccess)
			{
				_logger.LogError(null, $"Failed to create inventory transaction: {result.Error}");
				return result;
			}

			_logger.LogInformation("CreateInventoryTransaction completed successfully");
			return Result.Success();
		}
	}
}