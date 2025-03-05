namespace hoicham.Core.Application.DTOs.PurchaseOrderDTOs
{
	public class PurchaseOrderItemCreateDto
	{
		public Guid ProductId { get; set; }
		public int Quantity { get; set; }
		public decimal UnitPrice { get; set; }
	}
}
