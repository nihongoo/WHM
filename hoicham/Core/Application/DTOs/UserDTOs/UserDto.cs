namespace hoicham.Core.Application.DTOs.UserDTOs
{
	public class UserDto
	{
		public Guid Id { get; set; }
		public string Username { get; set; }
		public string Email { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Phone { get; set; }
		public Guid RoleId { get; set; }
		public string RoleName { get; set; } 
		public bool IsActive { get; set; }
		public DateTime LastLogin { get; set; }
		public DateTime CreatedAt { get; set; }
		public DateTime UpdatedAt { get; set; }
	}
}
