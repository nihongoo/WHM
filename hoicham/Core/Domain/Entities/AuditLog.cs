using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace hoicham.Core.Domain.Entities
{
    [Table("AuditLog")]
    public class AuditLog
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid UserId { get; set; }

        [Required]
        [StringLength(50)]
        public string Action { get; set; }

        [Required]
        [StringLength(50)]
        public string EntityName { get; set; }

        [Required]
        [StringLength(50)]
        public string EntityId { get; set; }

        [Column(TypeName = "nvarchar(max)")]
        public string OldValues { get; set; }

        [Column(TypeName = "nvarchar(max)")]
        public string NewValues { get; set; }

        [Required]
        [StringLength(50)]
        public string IPAddress { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }
    }
}
