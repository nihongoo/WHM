using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace hoicham.Core.Domain.Entities
{
    [Table("ProductCategories")]
    public class ProductCategory
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        [Column(TypeName = "varchar(50)")]
        public string Code { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        public Guid? ParentCategoryId { get; set; }

        [Required]
        public bool IsActive { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        [Required]
        public DateTime UpdatedAt { get; set; }

        //[ForeignKey("ParentCategoryId")]
        //public virtual ProductCategory ParentCategory { get; set; }

        //public virtual ICollection<ProductCategory> SubCategories { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}

