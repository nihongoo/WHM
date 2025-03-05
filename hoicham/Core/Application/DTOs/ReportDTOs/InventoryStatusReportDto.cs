namespace hoicham.Core.Application.DTOs.ReportDTOs
{
	public class InventoryStatusReportDto
	{
		public Guid ProductId { get; set; }
		public string ProductCode { get; set; }
		public string ProductName { get; set; }
		public Guid WarehouseId { get; set; }
		public string WarehouseCode { get; set; }
		public string WarehouseName { get; set; }
		public int CurrentStock { get; set; }
		public int MinimumStock { get; set; }
		public int MaximumStock { get; set; }
		public decimal Value { get; set; }
		public string Status { get; set; } // "Low", "Normal", "High"
	}
}
