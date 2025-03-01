using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace hoicham.Core.Domain.Entities
{
    [Table("PurchaseOrders")]
    public class PurchaseOrder
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [StringLength(50)]
        [Column(TypeName = "varchar(50)")]
        public string OrderNumber { get; set; }

        [Required]
        public Guid SupplierId { get; set; }

        [Required]
        public DateTime OrderDate { get; set; }

        [Required]
        public DateTime ExpectedDeliveryDate { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalAmount { get; set; }

        [Required]
        [StringLength(50)]
        public string Status { get; set; }

        [StringLength(500)]
        public string Notes { get; set; }

        [Required]
        public Guid CreatedById { get; set; }

        public Guid? ApprovedById { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        [Required]
        public DateTime UpdatedAt { get; set; }

        [ForeignKey("SupplierId")]
        public virtual Supplier Supplier { get; set; }

        [ForeignKey("CreatedById")]
        public virtual User CreatedBy { get; set; }

        public virtual ICollection<PurchaseOrderItem> Items { get; set; }
    }
}
