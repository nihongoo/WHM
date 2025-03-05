namespace hoicham.Core.Application.DTOs.SalesOrderDTOs
{
	public class SalesOrderDto
	{
		public Guid Id { get; set; }
		public string OrderNumber { get; set; }
		public Guid CustomerId { get; set; }
		public string CustomerName { get; set; } 
		public DateTime OrderDate { get; set; }
		public DateTime DeliveryDate { get; set; }
		public decimal TotalAmount { get; set; }
		public string Status { get; set; }
		public string Notes { get; set; }
		public Guid CreatedById { get; set; }
		public string CreatedByUserName { get; set; } 
		public DateTime CreatedAt { get; set; }
		public DateTime UpdatedAt { get; set; }
		public List<SalesOrderItemDto> Items { get; set; } = new List<SalesOrderItemDto>();
	}
}
