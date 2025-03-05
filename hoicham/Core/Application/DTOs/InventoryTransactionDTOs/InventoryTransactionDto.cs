namespace hoicham.Core.Application.DTOs.InventoryTransactionDTOs
{
	public class InventoryTransactionDto
	{
		public Guid Id { get; set; }
		public Guid ProductId { get; set; }
		public string ProductName { get; set; } // Navigation property
		public string ProductCode { get; set; } // Navigation property
		public Guid WarehouseId { get; set; }
		public string WarehouseName { get; set; } // Navigation property
		public Guid UserId { get; set; }
		public string UserName { get; set; } // Navigation property
		public string TransactionType { get; set; }
		public int Quantity { get; set; }
		public decimal UnitPrice { get; set; }
		public string ReferenceNumber { get; set; }
		public string Notes { get; set; }
		public Guid? SourceDocumentId { get; set; }
		public string SourceDocumentType { get; set; }
		public DateTime TransactionDate { get; set; }
		public DateTime CreatedAt { get; set; }
	}
}
