using hoicham.Core.Application.DTOs;
using hoicham.Core.Application.Services;
using hoicham.Core.Domain.Common;
using hoicham.Core.Ports.Input;
using hoicham.Core.Ports.Output.Services;

namespace hoicham.Core.Application.UseCases.Sales
{
	public class FulfillSalesOrderUseCase
	{
		private readonly ISalesOrderService _salesOrderService;
		private readonly ILoggerService _logger;

		public FulfillSalesOrderUseCase(ISalesOrderService salesOrderService, ILoggerService logger)
		{
			_salesOrderService = salesOrderService;
			_logger = logger;
		}

		public async Task<Result> ExecuteAsync(Guid salesOrderId, Guid warehouseId, Guid userId)
		{
			_logger.LogInformation($"Starting FulfillSalesOrder: {salesOrderId}, Warehouse: {warehouseId}");

			// Gọi service để hoàn tất đơn hàng
			var result = await _salesOrderService.FulfillSalesOrderAsync(salesOrderId, warehouseId, userId);
			if (!result.IsSuccess)
			{
				_logger.LogError(null, $"Failed to fulfill sales order: {result.Error}");
				return result;
			}

			_logger.LogInformation("FulfillSalesOrder completed successfully");
			return Result.Success();
		}
	}
}