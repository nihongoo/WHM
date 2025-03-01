using hoicham.Core.Ports.Input;
using hoicham.Core.Ports.Output.Repositories;
using hoicham.Core.Ports.Output.Services;

namespace hoicham.Core.Application.Services
{
	public class StockValidationService : IStockValidationService
	{
		private readonly IProductRepository _productRepository;
		private readonly IInventoryTransactionRepository _inventoryTransactionRepository;
		private readonly IWarehouseRepository _warehouseRepository;
		private readonly ILoggerService _logger;

		public StockValidationService(
			IProductRepository productRepository,
			IInventoryTransactionRepository inventoryTransactionRepository,
			IWarehouseRepository warehouseRepository,
			ILoggerService logger)
		{
			_productRepository = productRepository;
			_inventoryTransactionRepository = inventoryTransactionRepository;
			_warehouseRepository = warehouseRepository;
			_logger = logger;
		}

		public async Task<bool> ValidateStockLevelAsync(Guid productId, int quantity)
		{
			try
			{
				// Get product
				var product = await _productRepository.GetByIdAsync(productId);
				if (product == null)
					return false;

				// If product allows negative stock, we can always withdraw
				if (product.AllowNegativeStock)
					return true;

				// Get current stock level from transactions
				var transactions = await _inventoryTransactionRepository.GetByProductIdAsync(productId);
				int currentStock = transactions.Sum(t => t.Quantity);

				// Validate if we have enough stock
				return currentStock >= quantity;
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, $"Error validating stock level: {ex.Message}");
				return false;
			}
		}

		public async Task<bool> ValidateWarehouseCapacityAsync(Guid warehouseId, int additionalQuantity)
		{
			try
			{
				// Get warehouse
				var warehouse = await _warehouseRepository.GetByIdAsync(warehouseId);
				if (warehouse == null)
					return false;

				// If warehouse has unlimited capacity, return true
				if (warehouse.TotalCapacity <= 0)
					return true;

				// Calculate total volume needed by additional quantity
				var transactions = await _inventoryTransactionRepository.GetAllByWarehouseIdAsync(warehouseId);

				// Assuming each unit takes up 1 volume unit for simplicity
				// In a real app, we'd calculate based on product dimensions
				decimal currentUsedCapacity = warehouse.UsedCapacity;
				decimal projectedCapacity = currentUsedCapacity + additionalQuantity;

				return projectedCapacity <= warehouse.TotalCapacity;
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, $"Error validating warehouse capacity: {ex.Message}");
				return false;
			}
		}
	}
}
