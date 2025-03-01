using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace hoicham.Core.Domain.Entities
{
    [Table("Products")]
    public class Product
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [StringLength(50)]
        [Column(TypeName = "varchar(50)")]
        public string Code { get; set; }

        [Required]
        [StringLength(200)]
        public string Name { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal BasePrice { get; set; }

        [Required]
        public int MinimumStock { get; set; }

        [Required]
        public int MaximumStock { get; set; }

        [Required]
        [StringLength(50)]
        [Column(TypeName = "varchar(50)")]
        public string SKU { get; set; }

        [StringLength(50)]
        public string Barcode { get; set; }

        [Required]
        public Guid SupplierId { get; set; }

        [Required]
        public Guid CategoryId { get; set; }

        [Required]
        public Guid UnitId { get; set; }

        [Required]
        public bool AllowNegativeStock { get; set; }

        [Column(TypeName = "nvarchar(max)")]
        public string Specifications { get; set; }

        [Column(TypeName = "decimal(18,3)")]
        public decimal Weight { get; set; }

        [Column(TypeName = "decimal(18,3)")]
        public decimal Volume { get; set; }

        [Required]
        public bool IsActive { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        [Required]
        public DateTime UpdatedAt { get; set; }

        [Required]
        public Guid CreatedById { get; set; }

        [Required]
        public Guid UpdatedById { get; set; }

        [ForeignKey("SupplierId")]
        public virtual Supplier Supplier { get; set; }

        [ForeignKey("CategoryId")]
        public virtual ProductCategory Category { get; set; }

        [ForeignKey("UnitId")]
        public virtual ProductUnit Unit { get; set; }

        public virtual ICollection<SaleOrderItem> SaleOrderItems { get; set; }
        public virtual ICollection<InventoryTransaction> InventoryTransactions { get; set; }
        public virtual ICollection<ProductPriceHistory> PriceHistory { get; set; }
        public virtual ICollection<StockCount> StockCounts { get; set; }
        public virtual ICollection<ProductImage> Images { get; set; }
        public virtual ICollection<ProductLocation> Locations { get; set; }
        public virtual ICollection<PurchaseOrderItem> PurchaseOrderItems { get; set; }
    }
}
