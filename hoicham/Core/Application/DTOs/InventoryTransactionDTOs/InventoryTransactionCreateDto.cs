namespace hoicham.Core.Application.DTOs.InventoryTransactionDTOs
{
	public class InventoryTransactionCreateDto
	{
		public Guid ProductId { get; set; }
		public Guid WarehouseId { get; set; }
		public string TransactionType { get; set; }
		public int Quantity { get; set; }
		public decimal UnitPrice { get; set; }
		public string ReferenceNumber { get; set; }
		public string Notes { get; set; }
		public Guid? SourceDocumentId { get; set; }
		public string SourceDocumentType { get; set; }
		public DateTime TransactionDate { get; set; }
	}
}
