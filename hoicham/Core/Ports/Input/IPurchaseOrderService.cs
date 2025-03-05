using hoicham.Core.Application.DTOs;
using hoicham.Core.Application.DTOs.PurchaseOrderDTOs;
using hoicham.Core.Domain.Common;

namespace hoicham.Core.Ports.Input
{
	public interface IPurchaseOrderService
	{
		Task<Result> CreatePurchaseOrderAsync(PurchaseOrderCreateDto request, Guid userId);
		Task<Result> ReceivePurchaseOrderAsync(Guid purchaseOrderId, Guid warehouseId, Guid userId);
	}
}