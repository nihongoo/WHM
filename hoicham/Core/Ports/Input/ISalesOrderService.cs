using hoicham.Core.Application.DTOs;
using hoicham.Core.Application.DTOs.SalesOrderDTOs;
using hoicham.Core.Domain.Common;

namespace hoicham.Core.Ports.Input
{
	public interface ISalesOrderService
	{
		Task<Result> CreateSalesOrderAsync(SalesOrderCreateDto request, Guid userId);
		Task<Result> FulfillSalesOrderAsync(Guid salesOrderId, Guid warehouseId, Guid userId);
	}
}