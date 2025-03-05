using hoicham.Core.Application.DTOs.InventoryTransactionDTOs;
using hoicham.Core.Application.DTOs.StockCountDTOs;
using hoicham.Core.Domain.Common;
using hoicham.Core.Domain.Entities;
using hoicham.Core.Domain.Events.InventoryEvents;
using hoicham.Core.Ports.Input;
using hoicham.Core.Ports.Output.Repositories;
using hoicham.Core.Ports.Output.Services;

namespace hoicham.Core.Application.Services
{
	/// <summary>
	/// bruh quên up lên git XD
	/// </summary>
	public class InventoryService : IInventoryService
	{
		private readonly IProductRepository _productRepository;
		private readonly IInventoryTransactionRepository _inventoryTransactionRepository;
		private readonly IWarehouseRepository _warehouseRepository;
		private readonly IUnitOfWork _unitOfWork;
		private readonly ILoggerService _logger;
		private readonly IStockValidationService _stockValidationService;
		private readonly IEventDispatcher _eventDispatcher;
		private readonly IRepository<StockCount> _stockCountRepository;

		public InventoryService(
			IProductRepository productRepository,
			IInventoryTransactionRepository inventoryTransactionRepository,
			IWarehouseRepository warehouseRepository,
			IUnitOfWork unitOfWork,
			ILoggerService logger,
			IStockValidationService stockValidationService,
			IEventDispatcher eventDispatcher)
		{
			_productRepository = productRepository;
			_inventoryTransactionRepository = inventoryTransactionRepository;
			_warehouseRepository = warehouseRepository;
			_unitOfWork = unitOfWork;
			_logger = logger;
			_stockValidationService = stockValidationService;
			_eventDispatcher = eventDispatcher;
		}

		public async Task<Result> AdjustStockAsync(Guid productId, int quantity, string reason, Guid warehouseId)
		{
			try
			{
				// Validate product exists
				var product = await _productRepository.GetByIdAsync(productId);
				if (product == null)
					return Result.Failure($"Product with ID {productId} not found");

				// Determine transaction type
				string transactionType = quantity >= 0 ? "Stock In" : "Stock Out";

				// Create inventory transaction
				var transaction = new InventoryTransaction
				{
					Id = Guid.NewGuid(),
					ProductId = productId,
					TransactionType = transactionType,
					Quantity = quantity,
					UnitPrice = product.BasePrice,
					TransactionDate = DateTime.UtcNow,
					CreatedAt = DateTime.UtcNow,
					Notes = reason,
					WarehouseId = warehouseId
				};

				// Save transaction
				await _inventoryTransactionRepository.AddAsync(transaction);
				await _unitOfWork.SaveChangesAsync();

				// Log the action
				_logger.LogInformation($"Stock adjusted: Product: {productId}, Quantity: {quantity}, Reason: {reason}");

				// Check if stock is below minimum level after adjustment
				var transactions = await _inventoryTransactionRepository.GetByProductIdAsync(productId);
				int currentStock = transactions.Sum(t => t.Quantity);

				// Dispatch stock adjusted event
				int oldQuantity = currentStock - quantity;
				int newQuantity = currentStock;
				await _eventDispatcher.DispatchAsync(new StockUpdatedEvent(productId, oldQuantity, newQuantity, reason));

				if (currentStock < product.MinimumStock)
				{
					await _eventDispatcher.DispatchAsync(new LowStockEvent(productId, currentStock, product.MinimumStock, warehouseId));
					_logger.LogWarning($"Low stock alert: Product: {productId}, Current: {currentStock}, Minimum: {product.MinimumStock}");
				}

				return Result.Success();
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, $"Error adjusting stock: {ex.Message}");
				return Result.Failure($"Failed to adjust stock: {ex.Message}");
			}
		}

		public async Task<bool> CheckStockAvailabilityAsync(Guid productId, int quantity)
		{
			try
			{
				// Get current stock level
				var product = await _productRepository.GetByIdAsync(productId);
				if (product == null)
					return false;

				// Get total inventory from transactions
				var transactions = await _inventoryTransactionRepository.GetByProductIdAsync(productId);
				int currentStock = transactions.Sum(t => t.Quantity);

				// Check if requested quantity is available
				return currentStock >= quantity || product.AllowNegativeStock;
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, $"Error checking stock availability: {ex.Message}");
				return false;
			}
		}

		public async Task<Result> CreateInventoryTransactionAsync(InventoryTransactionCreateDto request, Guid userId)
		{
			try
			{
				// Validate product exists
				var product = await _productRepository.GetByIdAsync(request.ProductId);
				if (product == null)
					return Result.Failure($"Product with ID {request.ProductId} not found");

				// Validate warehouse exists
				var warehouse = await _warehouseRepository.GetByIdAsync(request.WarehouseId);
				if (warehouse == null)
					return Result.Failure($"Warehouse with ID {request.WarehouseId} not found");

				// Create transaction
				var transaction = new InventoryTransaction
				{
					Id = Guid.NewGuid(),
					ProductId = request.ProductId,
					WarehouseId = request.WarehouseId,
					UserId = userId,
					TransactionType = request.TransactionType,
					Quantity = request.Quantity,
					UnitPrice = request.UnitPrice,
					ReferenceNumber = request.ReferenceNumber,
					Notes = request.Notes,
					SourceDocumentId = request.SourceDocumentId,
					SourceDocumentType = request.SourceDocumentType,
					TransactionDate = request.TransactionDate,
					CreatedAt = DateTime.UtcNow
				};

				// Save transaction
				await _inventoryTransactionRepository.AddAsync(transaction);
				await _unitOfWork.SaveChangesAsync();

				// Log the action
				_logger.LogInformation($"Inventory transaction created: Product: {request.ProductId}, Warehouse: {request.WarehouseId}, Type: {request.TransactionType}, Quantity: {request.Quantity}");

				return Result.Success();
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, $"Error creating inventory transaction: {ex.Message}");
				return Result.Failure($"Failed to create inventory transaction: {ex.Message}");
			}
		}

		public async Task<Result> PerformStockCountAsync(StockCountCreateDto request, Guid userId)
		{
			try
			{
				// Validate product exists
				var product = await _productRepository.GetByIdAsync(request.ProductId);
				if (product == null)
					return Result.Failure($"Product with ID {request.ProductId} not found");

				// Validate warehouse exists
				var warehouse = await _warehouseRepository.GetByIdAsync(request.WarehouseId);
				if (warehouse == null)
					return Result.Failure($"Warehouse with ID {request.WarehouseId} not found");

				// Calculate system quantity
				var transactions = await _inventoryTransactionRepository.GetAllByProductAndWarehouseAsync(request.ProductId, request.WarehouseId);
				int systemQuantity = transactions.Sum(t => t.Quantity);

				// Create stock count
				var stockCount = new StockCount
				{
					Id = Guid.NewGuid(),
					ProductId = request.ProductId,
					WarehouseId = request.WarehouseId,
					SystemQuantity = systemQuantity,
					CountedQuantity = request.CountedQuantity,
					Discrepancy = request.CountedQuantity - systemQuantity,
					Notes = request.Notes,
					Status = "Pending", // Chờ duyệt
					CountDate = request.CountDate,
					//CountedByUserId = userId,
					CreatedAt = DateTime.UtcNow,
					UpdatedAt = DateTime.UtcNow
				};

				// Save stock count
				await _stockCountRepository.AddAsync(stockCount);
				await _unitOfWork.SaveChangesAsync();

				// Log the action
				_logger.LogInformation($"Stock count performed: Product: {request.ProductId}, Warehouse: {request.WarehouseId}, System: {systemQuantity}, Counted: {request.CountedQuantity}");

				return Result.Success();
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, $"Error performing stock count: {ex.Message}");
				return Result.Failure($"Failed to perform stock count: {ex.Message}");
			}
		}

		public async Task<Result> TransferStockAsync(Guid sourceWarehouseId, Guid targetWarehouseId, Guid productId, int quantity)
		{
			try
			{
				// Validate inputs
				if (quantity <= 0)
					return Result.Failure("Transfer quantity must be positive");

				// Validate warehouses exist
				var sourceWarehouse = await _warehouseRepository.GetByIdAsync(sourceWarehouseId);
				if (sourceWarehouse == null)
					return Result.Failure($"Source warehouse with ID {sourceWarehouseId} not found");

				var targetWarehouse = await _warehouseRepository.GetByIdAsync(targetWarehouseId);
				if (targetWarehouse == null)
					return Result.Failure($"Target warehouse with ID {targetWarehouseId} not found");

				// Validate product exists
				var product = await _productRepository.GetByIdAsync(productId);
				if (product == null)
					return Result.Failure($"Product with ID {productId} not found");

				// Check source warehouse has enough stock
				var sourceTransactions = await _inventoryTransactionRepository.GetAllByProductAndWarehouseAsync(productId, sourceWarehouseId);
				int sourceStock = sourceTransactions.Sum(t => t.Quantity);

				if (sourceStock < quantity)
					return Result.Failure($"Insufficient stock in source warehouse. Available: {sourceStock}, Requested: {quantity}");

				// Check target warehouse has capacity
				bool hasCapacity = await _stockValidationService.ValidateWarehouseCapacityAsync(targetWarehouseId, quantity);
				if (!hasCapacity)
					return Result.Failure("Target warehouse doesn't have enough capacity");

				// Create outbound transaction for source warehouse
				var outboundTransaction = new InventoryTransaction
				{
					Id = Guid.NewGuid(),
					ProductId = productId,
					WarehouseId = sourceWarehouseId,
					TransactionType = "Transfer Out",
					Quantity = -quantity,
					UnitPrice = product.BasePrice,
					TransactionDate = DateTime.UtcNow,
					CreatedAt = DateTime.UtcNow,
					Notes = $"Transfer to warehouse {targetWarehouse.Name}"
				};

				// Create inbound transaction for target warehouse
				var inboundTransaction = new InventoryTransaction
				{
					Id = Guid.NewGuid(),
					ProductId = productId,
					WarehouseId = targetWarehouseId,
					TransactionType = "Transfer In",
					Quantity = quantity,
					UnitPrice = product.BasePrice,
					TransactionDate = DateTime.UtcNow,
					CreatedAt = DateTime.UtcNow,
					Notes = $"Transfer from warehouse {sourceWarehouse.Name}"
				};

				// Link the transactions
				string transferId = Guid.NewGuid().ToString();
				outboundTransaction.ReferenceNumber = transferId;
				inboundTransaction.ReferenceNumber = transferId;

				// Save transactions
				await _inventoryTransactionRepository.AddAsync(outboundTransaction);
				await _inventoryTransactionRepository.AddAsync(inboundTransaction);
				await _unitOfWork.SaveChangesAsync();

				// Log the action
				_logger.LogInformation($"Stock transferred: Product: {productId}, From: {sourceWarehouseId}, To: {targetWarehouseId}, Quantity: {quantity}");

				// Dispatch stock transferred event
				await _eventDispatcher.DispatchAsync(new StockTransferredEvent(
					productId, sourceWarehouseId, targetWarehouseId, quantity));

				return Result.Success();
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, $"Error transferring stock: {ex.Message}");
				return Result.Failure($"Failed to transfer stock: {ex.Message}");
			}
		}
	}
}