namespace hoicham.Core.Application.DTOs.PurchaseOrderDTOs
{
	public class PurchaseOrderCreateDto
	{
		public Guid SupplierId { get; set; }
		public DateTime OrderDate { get; set; }
		public DateTime ExpectedDeliveryDate { get; set; }
		public string Notes { get; set; }
		public List<PurchaseOrderItemCreateDto> Items { get; set; } = new List<PurchaseOrderItemCreateDto>();
	}
}
