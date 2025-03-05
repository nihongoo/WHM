namespace hoicham.Core.Application.DTOs.UserDTOs
{
	public class UserCreateDto
	{
		public string Username { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Phone { get; set; }
		public Guid RoleId { get; set; }
		public bool IsActive { get; set; }
	}
}
