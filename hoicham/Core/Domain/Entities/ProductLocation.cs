using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace hoicham.Core.Domain.Entities
{
    [Table("ProductLocations")]
    public class ProductLocation
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [ForeignKey("Product")]
        public Guid ProductId { get; set; }
        public virtual Product Product { get; set; }

        [Required]
        [ForeignKey("Warehouse")]
        public Guid WarehouseId { get; set; }
        public virtual Warehouse Warehouse { get; set; }

        [Required]
        [StringLength(50)]
        public string Zone { get; set; }

        [Required]
        [StringLength(50)]
        public string Aisle { get; set; }

        [Required]
        [StringLength(50)]
        public string Rack { get; set; }

        [Required]
        [StringLength(50)]
        public string Shelf { get; set; }

        [Required]
        [StringLength(50)]
        public string Bin { get; set; }

        [Required]
        public DateTime LastUpdated { get; set; }
    }
}
