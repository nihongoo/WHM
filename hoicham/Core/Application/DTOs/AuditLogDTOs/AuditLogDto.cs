namespace hoicham.Core.Application.DTOs.AuditLogDTOs
{
	public class AuditLogDto
	{
		public Guid Id { get; set; }
		public Guid UserId { get; set; }
		public string UserName { get; set; } 
		public string Action { get; set; }
		public string EntityName { get; set; }
		public string EntityId { get; set; }
		public string OldValues { get; set; }
		public string NewValues { get; set; }
		public string IPAddress { get; set; }
		public DateTime CreatedAt { get; set; }
	}
}
