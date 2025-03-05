namespace hoicham.Core.Application.DTOs.SalesOrderDTOs
{
	public class SalesOrderUpdateDto
	{
		public Guid Id { get; set; }
		public DateTime DeliveryDate { get; set; }
		public string Status { get; set; }
		public string Notes { get; set; }
	}
}
