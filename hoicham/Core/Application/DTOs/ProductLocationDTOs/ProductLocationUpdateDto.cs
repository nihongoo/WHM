namespace hoicham.Core.Application.DTOs.ProductLocationDTOs
{
	public class ProductLocationUpdateDto
	{
		public Guid Id { get; set; }
		public string Zone { get; set; }
		public string Aisle { get; set; }
		public string Rack { get; set; }
		public string Shelf { get; set; }
		public string Bin { get; set; }
	}
}
