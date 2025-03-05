namespace hoicham.Core.Application.DTOs.UserDTOs
{
	public class UserRoleCreateDto
	{
		public string Name { get; set; }
		public string Description { get; set; }
		public string Permissions { get; set; }
		public bool IsActive { get; set; }
	}
}
