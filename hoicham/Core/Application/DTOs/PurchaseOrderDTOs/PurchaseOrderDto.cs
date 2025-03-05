namespace hoicham.Core.Application.DTOs.PurchaseOrderDTOs
{
	public class PurchaseOrderDto
	{
		public Guid Id { get; set; }
		public string OrderNumber { get; set; }
		public Guid SupplierId { get; set; }
		public string SupplierName { get; set; } 
		public DateTime OrderDate { get; set; }
		public DateTime ExpectedDeliveryDate { get; set; }
		public decimal TotalAmount { get; set; }
		public string Status { get; set; }
		public string Notes { get; set; }
		public Guid CreatedById { get; set; }
		public string CreatedByUserName { get; set; } 
		public Guid? ApprovedById { get; set; }
		public string ApprovedByUserName { get; set; } 
		public DateTime CreatedAt { get; set; }
		public DateTime UpdatedAt { get; set; }
		public List<PurchaseOrderItemDto> Items { get; set; } = new List<PurchaseOrderItemDto>();
	}
}
