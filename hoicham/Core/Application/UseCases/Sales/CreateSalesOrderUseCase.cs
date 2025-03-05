using hoicham.Core.Application.DTOs;
using hoicham.Core.Application.DTOs.SalesOrderDTOs;
using hoicham.Core.Application.Services;
using hoicham.Core.Domain.Common;
using hoicham.Core.Ports.Input;
using hoicham.Core.Ports.Output.Services;

namespace hoicham.Core.Application.UseCases.Sales
{
	public class CreateSalesOrderUseCase
	{
		private readonly ISalesOrderService _salesOrderService;
		private readonly ILoggerService _logger;

		public CreateSalesOrderUseCase(ISalesOrderService salesOrderService, ILoggerService logger)
		{
			_salesOrderService = salesOrderService;
			_logger = logger;
		}

		public async Task<Result> ExecuteAsync(SalesOrderCreateDto request, Guid userId)
		{
			_logger.LogInformation($"Starting CreateSalesOrder for Customer: {request.CustomerId}");

			// Validate input
			if (request.Items == null || !request.Items.Any())
			{
				_logger.LogWarning("Invalid sales order: At least one item is required");
				return Result.Failure("At least one item is required in the sales order");
			}

			// Gọi service để tạo đơn hàng
			var result = await _salesOrderService.CreateSalesOrderAsync(request, userId);
			if (!result.IsSuccess)
			{
				_logger.LogError(null, $"Failed to create sales order: {result.Error}");
				return result;
			}

			_logger.LogInformation("CreateSalesOrder completed successfully");
			return Result.Success();
		}
	}
}