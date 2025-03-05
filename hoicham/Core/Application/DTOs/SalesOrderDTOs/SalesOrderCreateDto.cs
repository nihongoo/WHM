namespace hoicham.Core.Application.DTOs.SalesOrderDTOs
{
	public class SalesOrderCreateDto
	{
		public Guid CustomerId { get; set; }
		public DateTime OrderDate { get; set; }
		public DateTime DeliveryDate { get; set; }
		public string Notes { get; set; }
		public List<SalesOrderItemCreateDto> Items { get; set; } = new List<SalesOrderItemCreateDto>();
	}
}
