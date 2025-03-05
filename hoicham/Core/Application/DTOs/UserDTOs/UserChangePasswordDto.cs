namespace hoicham.Core.Application.DTOs.UserDTOs
{
	public class UserChangePasswordDto
	{
		public Guid Id { get; set; }
		public string CurrentPassword { get; set; }
		public string NewPassword { get; set; }
		public string ConfirmPassword { get; set; }
	}
}
