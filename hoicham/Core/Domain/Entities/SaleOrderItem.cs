using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace hoicham.Core.Domain.Entities
{
    [Table("SalesOrderItems")]
    public class SaleOrderItem
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [ForeignKey("SalesOrder")]
        public Guid SalesOrderId { get; set; }
        public virtual SaleOrder SalesOrder { get; set; }

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

