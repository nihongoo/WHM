namespace hoicham.Core.Application.DTOs.PurchaseOrderDTOs
{
	public class PurchaseOrderItemDto
	{
		public Guid Id { get; set; }
		public Guid PurchaseOrderId { get; set; }
		public Guid ProductId { get; set; }
		public string ProductName { get; set; } 
		public string ProductCode { get; set; } 
		public int Quantity { get; set; }
		public decimal UnitPrice { get; set; }
		public decimal TotalPrice { get; set; }
		public DateTime CreatedAt { get; set; }
	}
}
