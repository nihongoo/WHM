namespace hoicham.Core.Application.DTOs.ProductLocationDTOs
{
	public class ProductLocationCreateDto
	{
		public Guid ProductId { get; set; }
		public Guid WarehouseId { get; set; }
		public string Zone { get; set; }
		public string Aisle { get; set; }
		public string Rack { get; set; }
		public string Shelf { get; set; }
		public string Bin { get; set; }
	}
}
