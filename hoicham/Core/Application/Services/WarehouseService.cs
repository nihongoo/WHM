using hoicham.Core.Domain.Common;
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
		public Task<Result> AllocateSpaceAsync(Guid warehouseId, Guid productId, int quantity)
		{
			throw new NotImplementedException();
		}

		public Task<Result> OptimizeStorageAsync(Guid warehouseId)
		{
			throw new NotImplementedException();
		}
	}
}
