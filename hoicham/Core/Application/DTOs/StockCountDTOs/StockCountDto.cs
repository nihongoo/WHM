namespace hoicham.Core.Application.DTOs.StockCountDTOs
{
	public class StockCountDto
	{
		public Guid Id { get; set; }
		public Guid ProductId { get; set; }
		public string ProductName { get; set; } 
		public string ProductCode { get; set; } 
		public Guid WarehouseId { get; set; }
		public string WarehouseName { get; set; } 
		public int SystemQuantity { get; set; }
		public int CountedQuantity { get; set; }
		public int Discrepancy { get; set; }
		public string Notes { get; set; }
		public string Status { get; set; }
		public DateTime CountDate { get; set; }
		public Guid CountedByUserId { get; set; }
		public string CountedByUserName { get; set; } 
		public Guid? ApprovedByUserId { get; set; }
		public string ApprovedByUserName { get; set; } 
		public DateTime CreatedAt { get; set; }
		public DateTime UpdatedAt { get; set; }
	}
}
