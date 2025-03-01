using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace hoicham.Core.Domain.Entities
{
    [Table("InventoryTransactions")]
    public class InventoryTransaction
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid ProductId { get; set; }

        [Required]
        public Guid WarehouseId { get; set; }

        [Required]
        public Guid UserId { get; set; }

        [Required]
        [StringLength(50)]
        public string TransactionType { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal UnitPrice { get; set; }

        [Required]
        [StringLength(50)]
        public string ReferenceNumber { get; set; }

        [StringLength(500)]
        public string Notes { get; set; }

        public Guid? SourceDocumentId { get; set; }

        [StringLength(50)]
        public string SourceDocumentType { get; set; }

        [Required]
        public DateTime TransactionDate { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }

        [ForeignKey("WarehouseId")]
        public virtual Warehouse Warehouse { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }
    }
}
