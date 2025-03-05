namespace hoicham.Core.Application.DTOs.PurchaseOrderDTOs
{
	public class PurchaseOrderUpdateDto
	{
		public Guid Id { get; set; }
		public DateTime ExpectedDeliveryDate { get; set; }
		public string Status { get; set; }
		public string Notes { get; set; }
	}
}
