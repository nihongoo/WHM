using hoicham.Core.Application.DTOs.InventoryTransactionDTOs;
using hoicham.Core.Application.DTOs.SalesOrderDTOs;
using hoicham.Core.Domain.Common;
using hoicham.Core.Domain.Entities;
using hoicham.Core.Ports.Input;
using hoicham.Core.Ports.Output.Repositories;
using hoicham.Core.Ports.Output.Services;
using hoicham.Infrastructure.Persistense.Repositories;

namespace hoicham.Core.Application.Services
{
	public class SalesOrderService : ISalesOrderService
	{
		private readonly IRepository<SaleOrder> _salesOrderRepository;
		private readonly IInventoryService _inventoryService;
		private readonly IUnitOfWork _unitOfWork;
		private readonly ILoggerService _logger;

		public SalesOrderService(
			IRepository<SaleOrder> salesOrderRepository,
			IInventoryService inventoryService,
			IUnitOfWork unitOfWork,
			ILoggerService logger)
		{
			_salesOrderRepository = salesOrderRepository;
			_inventoryService = inventoryService;
			_unitOfWork = unitOfWork;
			_logger = logger;
		}

		public async Task<Result> CreateSalesOrderAsync(SalesOrderCreateDto request, Guid userId)
		{
			try
			{
				// Tạo sales order
				var salesOrder = new SaleOrder
				{
					Id = Guid.NewGuid(),
					OrderNumber = $"SO-{DateTime.UtcNow:yyyyMMddHHmmss}",
					CustomerId = request.CustomerId,
					OrderDate = request.OrderDate,
					DeliveryDate = request.DeliveryDate,
					TotalAmount = request.Items.Sum(i => i.Quantity * i.UnitPrice),
					Status = "Pending",
					Notes = request.Notes,
					CreatedById = userId,
					CreatedAt = DateTime.UtcNow,
					UpdatedAt = DateTime.UtcNow
				};

				// Tạo items
				salesOrder.Items = request.Items.Select(item => new SaleOrderItem
				{
					Id = Guid.NewGuid(),
					SalesOrderId = salesOrder.Id,
					ProductId = item.ProductId,
					Quantity = item.Quantity,
					UnitPrice = item.UnitPrice,
					TotalPrice = item.Quantity * item.UnitPrice,
					CreatedAt = DateTime.UtcNow
				}).ToList();

				// Lưu sales order
				await _salesOrderRepository.AddAsync(salesOrder);
				await _unitOfWork.SaveChangesAsync();

				// Log the action
				_logger.LogInformation($"Sales order created: {salesOrder.Id}, Customer: {salesOrder.CustomerId}");

				return Result.Success();
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, $"Error creating sales order: {ex.Message}");
				return Result.Failure($"Failed to create sales order: {ex.Message}");
			}
		}

		public async Task<Result> FulfillSalesOrderAsync(Guid salesOrderId, Guid warehouseId, Guid userId)
		{
			try
			{
				// Validate sales order exists
				var salesOrder = await _salesOrderRepository.GetByIdAsync(salesOrderId);
				if (salesOrder == null)
					return Result.Failure($"Sales order with ID {salesOrderId} not found");

				// Validate status
				if (salesOrder.Status != "Approved")
					return Result.Failure($"Sales order must be approved before fulfilling. Current status: {salesOrder.Status}");

				// Xuất hàng: tạo giao dịch xuất kho cho từng item
				foreach (var item in salesOrder.Items)
				{
					var transactionDto = new InventoryTransactionCreateDto
					{
						ProductId = item.ProductId,
						WarehouseId = warehouseId,
						TransactionType = "Sale",
						Quantity = -item.Quantity, // Xuất kho nên quantity là âm
						UnitPrice = item.UnitPrice,
						ReferenceNumber = salesOrder.OrderNumber,
						Notes = $"Fulfilled from sales order {salesOrder.OrderNumber}",
						SourceDocumentId = salesOrder.Id,
						SourceDocumentType = "SalesOrder",
						TransactionDate = DateTime.UtcNow
					};

					var transactionResult = await _inventoryService.CreateInventoryTransactionAsync(transactionDto, userId);
					if (!transactionResult.IsSuccess)
						return transactionResult;
				}

				// Cập nhật trạng thái sales order
				salesOrder.Status = "Fulfilled";
				salesOrder.UpdatedAt = DateTime.UtcNow;
				await _salesOrderRepository.UpdateAsync(salesOrder);
				await _unitOfWork.SaveChangesAsync();

				// Log the action
				_logger.LogInformation($"Sales order fulfilled: {salesOrder.Id}, Warehouse: {warehouseId}");

				return Result.Success();
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, $"Error fulfilling sales order: {ex.Message}");
				return Result.Failure($"Failed to fulfill sales order: {ex.Message}");
			}
		}
	}
}