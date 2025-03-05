namespace hoicham.Core.Application.DTOs.StockCountDTOs
{
	public class StockCountCreateDto
	{
		public Guid ProductId { get; set; }
		public Guid WarehouseId { get; set; }
		public int CountedQuantity { get; set; }
		public string Notes { get; set; }
		public DateTime CountDate { get; set; }
	}
}
