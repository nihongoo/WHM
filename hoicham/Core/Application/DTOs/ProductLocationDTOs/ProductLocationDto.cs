namespace hoicham.Core.Application.DTOs.ProductLocationDTOs
{
	public class ProductLocationDto
	{
		public Guid Id { get; set; }
		public Guid ProductId { get; set; }
		public string ProductName { get; set; } 
		public string ProductCode { get; set; } 
		public Guid WarehouseId { get; set; }
		public string WarehouseName { get; set; } 
		public string Zone { get; set; }
		public string Aisle { get; set; }
		public string Rack { get; set; }
		public string Shelf { get; set; }
		public string Bin { get; set; }
		public DateTime LastUpdated { get; set; }
	}
}
