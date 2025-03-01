using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace hoicham.Core.Domain.Entities
{
    [Table("Users")]
    public class User
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [StringLength(50)]
        [Column(TypeName = "varchar(50)")]
        public string Username { get; set; }

        [Required]
        [StringLength(100)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(100)]
        public string PasswordHash { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [StringLength(20)]
        public string Phone { get; set; }

        [Required]
        public Guid RoleId { get; set; }

        [Required]
        public bool IsActive { get; set; }

        public DateTime? LastLogin { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        [Required]
        public DateTime UpdatedAt { get; set; }

        [ForeignKey("RoleId")]
        public virtual UserRole Role { get; set; }

        public virtual ICollection<InventoryTransaction> InventoryTransactions { get; set; }
        public virtual ICollection<SaleOrder> SalesOrders { get; set; }
        public virtual ICollection<PurchaseOrder> CreatedPurchaseOrders { get; set; }
        public virtual ICollection<AuditLog> AuditLogs { get; set; }
    }
}
