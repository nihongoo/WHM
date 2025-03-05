using hoicham.Core.Application.DTOs;
using hoicham.Core.Application.Services;
using hoicham.Core.Domain.Common;
using hoicham.Core.Ports.Input;
using hoicham.Core.Ports.Output.Services;

namespace hoicham.Core.Application.UseCases.Purchases
{
	public class ReceivePurchaseOrderUseCase
	{
		private readonly IPurchaseOrderService _purchaseOrderService;
		private readonly ILoggerService _logger;

		public ReceivePurchaseOrderUseCase(IPurchaseOrderService purchaseOrderService, ILoggerService logger)
		{
			_purchaseOrderService = purchaseOrderService;
			_logger = logger;
		}

		public async Task<Result> ExecuteAsync(Guid purchaseOrderId, Guid warehouseId, Guid userId)
		{
			_logger.LogInformation($"Starting ReceivePurchaseOrder: {purchaseOrderId}, Warehouse: {warehouseId}");

			// Gọi service để nhận hàng
			var result = await _purchaseOrderService.ReceivePurchaseOrderAsync(purchaseOrderId, warehouseId, userId);
			if (!result.IsSuccess)
			{
				_logger.LogError(null, $"Failed to receive purchase order: {result.Error}");
				return result;
			}

			_logger.LogInformation("ReceivePurchaseOrder completed successfully");
			return Result.Success();
		}
	}
}