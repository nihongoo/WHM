using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace hoicham.Core.Domain.Entities
{
    [Table("Customer")]
    public class Customer
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [StringLength(50)]
        [Column(TypeName = "nvarchar(50)")]
        public string Code { get; set; }

        [Required]
        [StringLength(100)]
        [Column(TypeName = "nvarchar(100)")]
        public string Name { get; set; }

        [StringLength(100)]
        [Column(TypeName = "nvarchar(100)")]
        public string ContactPerson { get; set; }

        [StringLength(100)]
        [Column(TypeName = "nvarchar(100)")]
        public string Email { get; set; }

        [StringLength(20)]
        [Column(TypeName = "nvarchar(20)")]
        public string Phone { get; set; }

        [StringLength(200)]
        [Column(TypeName = "nvarchar(200)")]
        public string Address { get; set; }

        [StringLength(50)]
        [Column(TypeName = "nvarchar(50)")]
        public string TaxNumber { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal CreditLimit { get; set; }

        [Required]
        public bool IsActive { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        [Required]
        public DateTime UpdatedAt { get; set; }

        public virtual ICollection<SaleOrder> SaleOrders { get; set; }
    }
}
