using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace hoicham.Core.Domain.Entities
{
    [Table("ProductImages")]
    public class ProductImage
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid ProductId { get; set; }

        [Required]
        [StringLength(500)]
        public string ImageUrl { get; set; }

        [StringLength(500)]
        public string ThumbnailUrl { get; set; }

        [Required]
        public bool IsPrimary { get; set; }

        [Required]
        public int SortOrder { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }
    }
}
