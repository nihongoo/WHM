using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace hoicham.Core.Domain.Entities
{
    [Table("Warehouses")]
    public class Warehouse
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [StringLength(50)]
        [Column(TypeName = "varchar(50)")]
        public string Code { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(500)]
        public string Address { get; set; }

        [StringLength(20)]
        public string Phone { get; set; }

        [StringLength(100)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalCapacity { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal UsedCapacity { get; set; }

        [Required]
        public bool IsActive { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        [Required]
        public DateTime UpdatedAt { get; set; }

        public virtual ICollection<InventoryTransaction> InventoryTransactions { get; set; }
        public virtual ICollection<ProductLocation> ProductLocations { get; set; }
        public virtual ICollection<StockCount> StockCounts { get; set; }
    }
}