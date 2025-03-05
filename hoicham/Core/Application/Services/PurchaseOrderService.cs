using hoicham.Core.Application.DTOs.InventoryTransactionDTOs;
using hoicham.Core.Application.DTOs.PurchaseOrderDTOs;
using hoicham.Core.Domain.Common;
using hoicham.Core.Domain.Entities;
using hoicham.Core.Ports.Input;
using hoicham.Core.Ports.Output.Repositories;
using hoicham.Core.Ports.Output.Services;

namespace hoicham.Core.Application.Services
{
	public class PurchaseOrderService : IPurchaseOrderService
	{
		private readonly IRepository<PurchaseOrder> _purchaseOrderRepository;
		private readonly IInventoryService _inventoryService;
		private readonly IUnitOfWork _unitOfWork;
		private readonly ILoggerService _logger;

		public PurchaseOrderService(
			IRepository<PurchaseOrder> purchaseOrderRepository,
			IInventoryService inventoryService,
			IUnitOfWork unitOfWork,
			ILoggerService logger)
		{
			_purchaseOrderRepository = purchaseOrderRepository;
			_inventoryService = inventoryService;
			_unitOfWork = unitOfWork;
			_logger = logger;
		}

		public async Task<Result> CreatePurchaseOrderAsync(PurchaseOrderCreateDto request, Guid userId)
		{
			try
			{
				// Tạo purchase order
				var purchaseOrder = new PurchaseOrder
				{
					Id = Guid.NewGuid(),
					OrderNumber = $"PO-{DateTime.UtcNow:yyyyMMddHHmmss}",
					SupplierId = request.SupplierId,
					OrderDate = request.OrderDate,
					ExpectedDeliveryDate = request.ExpectedDeliveryDate,
					TotalAmount = request.Items.Sum(i => i.Quantity * i.UnitPrice),
					Status = "Pending",
					Notes = request.Notes,
					CreatedById = userId,
					CreatedAt = DateTime.UtcNow,
					UpdatedAt = DateTime.UtcNow
				};

				// Tạo items
				purchaseOrder.Items = request.Items.Select(item => new PurchaseOrderItem
				{
					Id = Guid.NewGuid(),
					PurchaseOrderId = purchaseOrder.Id,
					ProductId = item.ProductId,
					Quantity = item.Quantity,
					UnitPrice = item.UnitPrice,
					TotalPrice = item.Quantity * item.UnitPrice,
					CreatedAt = DateTime.UtcNow
				}).ToList();

				// Lưu purchase order
				await _purchaseOrderRepository.AddAsync(purchaseOrder);
				await _unitOfWork.SaveChangesAsync();

				// Log the action
				_logger.LogInformation($"Purchase order created: {purchaseOrder.Id}, Supplier: {purchaseOrder.SupplierId}");

				return Result.Success();
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, $"Error creating purchase order: {ex.Message}");
				return Result.Failure($"Failed to create purchase order: {ex.Message}");
			}
		}

		public async Task<Result> ReceivePurchaseOrderAsync(Guid purchaseOrderId, Guid warehouseId, Guid userId)
		{
			try
			{
				// Validate purchase order exists
				var purchaseOrder = await _purchaseOrderRepository.GetByIdAsync(purchaseOrderId);
				if (purchaseOrder == null)
					return Result.Failure($"Purchase order with ID {purchaseOrderId} not found");

				// Validate status
				if (purchaseOrder.Status != "Approved")
					return Result.Failure($"Purchase order must be approved before receiving. Current status: {purchaseOrder.Status}");

				// Nhận hàng: tạo giao dịch nhập kho cho từng item
				foreach (var item in purchaseOrder.Items)
				{
					var transactionDto = new InventoryTransactionCreateDto
					{
						ProductId = item.ProductId,
						WarehouseId = warehouseId,
						TransactionType = "Receive",
						Quantity = item.Quantity,
						UnitPrice = item.UnitPrice,
						ReferenceNumber = purchaseOrder.OrderNumber,
						Notes = $"Received from purchase order {purchaseOrder.OrderNumber}",
						SourceDocumentId = purchaseOrder.Id,
						SourceDocumentType = "PurchaseOrder",
						TransactionDate = DateTime.UtcNow
					};

					var transactionResult = await _inventoryService.CreateInventoryTransactionAsync(transactionDto, userId);
					if (!transactionResult.IsSuccess)
						return transactionResult;
				}

				// Cập nhật trạng thái purchase order
				purchaseOrder.Status = "Received";
				purchaseOrder.UpdatedAt = DateTime.UtcNow;
				await _purchaseOrderRepository.UpdateAsync(purchaseOrder);
				await _unitOfWork.SaveChangesAsync();

				// Log the action
				_logger.LogInformation($"Purchase order received: {purchaseOrder.Id}, Warehouse: {warehouseId}");

				return Result.Success();
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, $"Error receiving purchase order: {ex.Message}");
				return Result.Failure($"Failed to receive purchase order: {ex.Message}");
			}
		}
	}
}