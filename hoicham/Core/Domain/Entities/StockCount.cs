using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace hoicham.Core.Domain.Entities
{
    [Table("StockCounts")]
    public class StockCount
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
        public int SystemQuantity { get; set; }

        [Required]
        public int CountedQuantity { get; set; }

        public int Discrepancy { get; set; }

        [Column(TypeName = "nvarchar(max)")]
        public string Notes { get; set; }

        [Required]
        [StringLength(50)]
        public string Status { get; set; }

        [Required]
        public DateTime CountDate { get; set; }

        //[Required]
        //[ForeignKey("CountedByUser")]
        //public Guid CountedByUserId { get; set; }
        //public virtual User CountedByUser { get; set; }

        //[ForeignKey("ApprovedByUser")]
        //public Guid? ApprovedByUserId { get; set; }
        //public virtual User ApprovedByUser { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        [Required]
        public DateTime UpdatedAt { get; set; }
    }
}
