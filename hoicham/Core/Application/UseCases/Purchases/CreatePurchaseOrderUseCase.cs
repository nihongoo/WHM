using hoicham.Core.Application.DTOs;
using hoicham.Core.Application.DTOs.PurchaseOrderDTOs;
using hoicham.Core.Application.Services;
using hoicham.Core.Domain.Common;
using hoicham.Core.Ports.Input;
using hoicham.Core.Ports.Output.Services;

namespace hoicham.Core.Application.UseCases.Purchases
{
	public class CreatePurchaseOrderUseCase
	{
		private readonly IPurchaseOrderService _purchaseOrderService;
		private readonly ILoggerService _logger;

		public CreatePurchaseOrderUseCase(IPurchaseOrderService purchaseOrderService, ILoggerService logger)
		{
			_purchaseOrderService = purchaseOrderService;
			_logger = logger;
		}

		public async Task<Result> ExecuteAsync(PurchaseOrderCreateDto request, Guid userId)
		{
			_logger.LogInformation($"Starting CreatePurchaseOrder for Supplier: {request.SupplierId}");

			// Validate input
			if (request.Items == null || !request.Items.Any())
			{
				_logger.LogWarning("Invalid purchase order: At least one item is required");
				return Result.Failure("At least one item is required in the purchase order");
			}

			// Gọi service để tạo đơn đặt hàng
			var result = await _purchaseOrderService.CreatePurchaseOrderAsync(request, userId);
			if (!result.IsSuccess)
			{
				_logger.LogError(null, $"Failed to create purchase order: {result.Error}");
				return result;
			}

			_logger.LogInformation("CreatePurchaseOrder completed successfully");
			return Result.Success();
		}
	}
}