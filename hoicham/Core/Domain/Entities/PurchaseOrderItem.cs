using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace hoicham.Core.Domain.Entities
{
    [Table("PurchaseOrderItems")]
    public class PurchaseOrderItem
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [ForeignKey("PurchaseOrder")]
        public Guid PurchaseOrderId { get; set; }

        [DeleteBehavior(DeleteBehavior.NoAction)]
        public virtual PurchaseOrder PurchaseOrder { get; set; }

        [Required]
        [ForeignKey("Product")]
        public Guid ProductId { get; set; }
        public virtual Product Product { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int Quantity { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal UnitPrice { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalPrice { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }
    }
}
