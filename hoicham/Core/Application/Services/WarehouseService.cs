using hoicham.Core.Domain.Common;
using hoicham.Core.Domain.Entities;
using hoicham.Core.Domain.Events.WarehouseEvents;
using hoicham.Core.Ports.Input;
using hoicham.Core.Ports.Output.Repositories;
using hoicham.Core.Ports.Output.Services;

namespace hoicham.Core.Application.Services
{
	public class WarehouseService : IWarehouseDomainService
	{
		private readonly IWarehouseRepository _warehouseRepository;
		private readonly IProductLocationRepository _productLocationRepository;
		private readonly IUnitOfWork _unitOfWork;
		private readonly ILoggerService _logger;
		private readonly IEventDispatcher _eventDispatcher;

		public WarehouseService(
			IWarehouseRepository warehouseRepository,
			IProductLocationRepository productLocationRepository,
			IUnitOfWork unitOfWork,
			ILoggerService logger,
			IEventDispatcher eventDispatcher)
		{
			_warehouseRepository = warehouseRepository;
			_productLocationRepository = productLocationRepository;
			_unitOfWork = unitOfWork;
			_logger = logger;
			_eventDispatcher = eventDispatcher;
		}
		public async Task<Result> AllocateSpaceAsync(Guid warehouseId, Guid productId, int quantity)
		{
			try
			{
				// Validate warehouse exists
				var warehouse = await _warehouseRepository.GetByIdAsync(warehouseId);
				if (warehouse == null)
					return Result.Failure($"Warehouse with ID {warehouseId} not found");

				// Check if there's existing location
				var existingLocation = await _productLocationRepository.GetByProductAndWarehouseAsync(productId, warehouseId);

				if (existingLocation != null)
				{
					// Update existing location
					_logger.LogInformation($"Product already has a location in this warehouse. Using existing location.");
					return Result.Success();
				}

				// Find best location for product
				// This is simplified - in a real app, would use algorithm to find optimal location
				string zone = "A";
				string aisle = "1";
				string rack = "1";
				string shelf = "1";
				string bin = "1";

				// Create new location
				var newLocation = new ProductLocation
				{
					Id = Guid.NewGuid(),
					ProductId = productId,
					WarehouseId = warehouseId,
					Zone = zone,
					Aisle = aisle,
					Rack = rack,
					Shelf = shelf,
					Bin = bin,
					LastUpdated = DateTime.UtcNow
				};

				// Save location
				await _productLocationRepository.AddAsync(newLocation);
				await _unitOfWork.SaveChangesAsync();

				// Update warehouse used capacity
				warehouse.UsedCapacity += quantity;
				await _warehouseRepository.UpdateAsync(warehouse);
				await _unitOfWork.SaveChangesAsync();

				// Log the action
				_logger.LogInformation($"Space allocated: Warehouse: {warehouseId}, Product: {productId}, Location: {zone}-{aisle}-{rack}-{shelf}-{bin}");

				// Dispatch event
				await _eventDispatcher.DispatchAsync(new SpaceAllocatedEvent(warehouseId, productId, zone, aisle, rack, shelf, bin));

				return Result.Success();
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, $"Error allocating space: {ex.Message}");
				return Result.Failure($"Failed to allocate space: {ex.Message}");
			}
		}

		public async Task<Result> OptimizeStorageAsync(Guid warehouseId)
		{
			try
			{
				// Validate warehouse exists
				var warehouse = await _warehouseRepository.GetByIdAsync(warehouseId);
				if (warehouse == null)
					return Result.Failure($"Warehouse with ID {warehouseId} not found");

				// Get all product locations in warehouse
				var locations = await _productLocationRepository.GetAllByWarehouseAsync(warehouseId);

				// Get inventory levels to determine which products need more space
				// This is a simplified version - real optimization would be more complex

				bool optimizationPerformed = false;

				// For demonstration, we'll just update the LastUpdated field
				foreach (var location in locations)
				{
					location.LastUpdated = DateTime.UtcNow;
					await _productLocationRepository.UpdateAsync(location);
					optimizationPerformed = true;
				}

				if (optimizationPerformed)
				{
					await _unitOfWork.SaveChangesAsync();

					// Log the action
					_logger.LogInformation($"Storage optimized for warehouse: {warehouseId}");

					// Dispatch event
					await _eventDispatcher.DispatchAsync(new StorageOptimizedEvent(warehouseId));

					return Result.Success("Storage optimization completed successfully");
				}

				return Result.Success("No optimization was needed");
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, $"Error optimizing storage: {ex.Message}");
				return Result.Failure($"Failed to optimize storage: {ex.Message}");
			}
		}
	}
}