using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace hoicham.Core.Domain.Entities
{
    [Table("ProductPriceHistories")]
    public class ProductPriceHistory
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid ProductId { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal OldPrice { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal NewPrice { get; set; }

        [Required]
        public DateTime EffectiveDate { get; set; }

        [StringLength(500)]
        public string Reason { get; set; }

        [Required]
        public Guid UpdatedById { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }

        //[ForeignKey("UpdatedById")]
        //public virtual User UpdatedBy { get; set; }
    }
}
