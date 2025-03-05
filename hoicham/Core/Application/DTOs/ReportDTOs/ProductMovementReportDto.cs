namespace hoicham.Core.Application.DTOs.ReportDTOs
{
	public class ProductMovementReportDto
	{
		public Guid ProductId { get; set; }
		public string ProductCode { get; set; }
		public string ProductName { get; set; }
		public Guid WarehouseId { get; set; }
		public string WarehouseCode { get; set; }
		public string WarehouseName { get; set; }
		public int TotalIn { get; set; }
		public int TotalOut { get; set; }
		public int NetMovement { get; set; }
		public DateTime StartDate { get; set; }
		public DateTime EndDate { get; set; }
	}
}
