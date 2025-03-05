namespace hoicham.Core.Application.DTOs.SalesOrderDTOs
{
	public class SalesOrderItemDto
	{
		public Guid Id { get; set; }
		public Guid SalesOrderId { get; set; }
		public Guid ProductId { get; set; }
		public string ProductName { get; set; } 
		public string ProductCode { get; set; } 
		public int Quantity { get; set; }
		public decimal UnitPrice { get; set; }
		public decimal TotalPrice { get; set; }
		public DateTime CreatedAt { get; set; }
	}
}
