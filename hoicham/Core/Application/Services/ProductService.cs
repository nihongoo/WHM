using hoicham.Core.Application.DTOs.ProductDTOs;
using hoicham.Core.Domain.Common;
using hoicham.Core.Domain.Entities;
using hoicham.Core.Domain.Events.ProductEvents;
using hoicham.Core.Ports.Input;
using hoicham.Core.Ports.Output.Repositories;
using hoicham.Core.Ports.Output.Services;

namespace hoicham.Core.Application.Services
{
	public class ProductService : IProductDomainService
	{
		private readonly IProductRepository _productRepository;
		private readonly IInventoryTransactionRepository _inventoryTransactionRepository;
		private readonly IUnitOfWork _unitOfWork;
		private readonly ILoggerService _logger;
		private readonly IEventDispatcher _eventDispatcher;

		public ProductService(
			IProductRepository productRepository,
			IInventoryTransactionRepository inventoryTransactionRepository,
			IUnitOfWork unitOfWork,
			ILoggerService logger,
			IEventDispatcher eventDispatcher)
		{
			_productRepository = productRepository;
			_inventoryTransactionRepository = inventoryTransactionRepository;
			_unitOfWork = unitOfWork;
			_logger = logger;
			_eventDispatcher = eventDispatcher;
		}

		public async Task<Result> CreateProductAsync(string name, string description, decimal price, int initialStock)
		{
			try
			{
				// Validate inputs
				if (string.IsNullOrWhiteSpace(name))
					return Result.Failure("Product name cannot be empty");

				if (price < 0)
					return Result.Failure("Product price cannot be negative");

				// Check if product with same name already exists
				var existingProduct = await _productRepository.GetByNameAsync(name);
				if (existingProduct != null)
					return Result.Failure($"Product with name '{name}' already exists");

				// Create new product
				var product = new Product
				{
					Id = Guid.NewGuid(),
					Name = name,
					Description = description,
					BasePrice = price,
					IsActive = true,
					CreatedAt = DateTime.UtcNow,
					UpdatedAt = DateTime.UtcNow
				};

				// Save product
				await _productRepository.AddAsync(product);

				// If initial stock is provided, create inventory transaction
				if (initialStock > 0)
				{
					var transaction = new InventoryTransaction
					{
						Id = Guid.NewGuid(),
						ProductId = product.Id,
						TransactionType = "Initial Stock",
						Quantity = initialStock,
						UnitPrice = price,
						TransactionDate = DateTime.UtcNow,
						CreatedAt = DateTime.UtcNow,
						Notes = "Initial stock on product creation"
					};

					await _inventoryTransactionRepository.AddAsync(transaction);
				}

				// Save all changes
				await _unitOfWork.SaveChangesAsync();

				// Log the action
				_logger.LogInformation($"Product created: {product.Id}, Name: {name}, Initial Stock: {initialStock}");

				// Dispatch product created event
				await _eventDispatcher.DispatchAsync(new ProductCreatedEvent(product.Id, name, price));

				return Result.Success(product.Id);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, $"Error creating product: {ex.Message}");
				return Result.Failure($"Failed to create product: {ex.Message}");
			}
		}

		public async Task<Result> UpdateProductAsync(ProductUpdateDto request, Guid userId)
		{
			try
			{
				// Validate product exists
				var product = await _productRepository.GetByIdAsync(request.Id);
				if (product == null)
					return Result.Failure($"Product with ID {request.Id} not found");

				// Update product
				product.Code = request.Code;
				product.Name = request.Name;
				product.Description = request.Description;
				product.BasePrice = request.BasePrice;
				product.MinimumStock = request.MinimumStock;
				product.MaximumStock = request.MaximumStock;
				product.SKU = request.SKU;
				product.Barcode = request.Barcode;
				product.SupplierId = request.SupplierId;
				product.CategoryId = request.CategoryId;
				product.UnitId = request.UnitId;
				product.AllowNegativeStock = request.AllowNegativeStock;
				product.Specifications = request.Specifications;
				product.Weight = request.Weight;
				product.Volume = request.Volume;
				product.IsActive = request.IsActive;
				product.UpdatedAt = DateTime.UtcNow;
				product.UpdatedById = userId;

				// Save changes
				await _productRepository.UpdateAsync(product);
				await _unitOfWork.SaveChangesAsync();

				// Log the action
				_logger.LogInformation($"Product updated: {product.Id}, Name: {product.Name}");

				return Result.Success();
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, $"Error updating product: {ex.Message}");
				return Result.Failure($"Failed to update product: {ex.Message}");
			}
		}

		public async Task<Result> DeleteProductAsync(Guid productId)
		{
			try
			{
				// Validate product exists
				var product = await _productRepository.GetByIdAsync(productId);
				if (product == null)
					return Result.Failure($"Product with ID {productId} not found");

				// Delete product
				await _productRepository.DeleteAsync(product.Id);
				await _unitOfWork.SaveChangesAsync();

				// Log the action
				_logger.LogInformation($"Product deleted: {productId}");

				return Result.Success();
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, $"Error deleting product: {ex.Message}");
				return Result.Failure($"Failed to delete product: {ex.Message}");
			}
		}
		public async Task<Result> UpdateProductPriceAsync(Guid productId, decimal newPrice)
		{
			try
			{
				// Validate inputs
				if (productId == Guid.Empty)
					return Result.Failure("Invalid product ID");

				if (newPrice < 0)
					return Result.Failure("Product price cannot be negative");

				// Get product
				var product = await _productRepository.GetByIdAsync(productId);
				if (product == null)
					return Result.Failure($"Product with ID {productId} not found");

				// Create price history record
				var priceHistory = new ProductPriceHistory
				{
					Id = Guid.NewGuid(),
					ProductId = productId,
					OldPrice = product.BasePrice,
					NewPrice = newPrice,
					EffectiveDate = DateTime.UtcNow,
					CreatedAt = DateTime.UtcNow,
					Reason = "Manual price update"
				};

				// Update product price
				product.BasePrice = newPrice;
				product.UpdatedAt = DateTime.UtcNow;

				// Save changes
				await _productRepository.UpdateAsync(product);
				await _unitOfWork.SaveChangesAsync();

				// Log the action
				_logger.LogInformation($"Product price updated: {productId}, Old Price: {priceHistory.OldPrice}, New Price: {newPrice}");

				// Dispatch price updated event
				await _eventDispatcher.DispatchAsync(new ProductUpdatedEvent(productId, priceHistory.OldPrice, newPrice));

				return Result.Success();
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, $"Error updating product price: {ex.Message}");
				return Result.Failure($"Failed to update product price: {ex.Message}");
			}
		}
	}
}
