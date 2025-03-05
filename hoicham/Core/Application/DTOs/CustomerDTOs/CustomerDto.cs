namespace hoicham.Core.Application.DTOs.CustomerDTOs
{
	public class CustomerDto
	{
		public Guid Id { get; set; }
		public string Code { get; set; }
		public string Name { get; set; }
		public string ContactPerson { get; set; }
		public string Email { get; set; }
		public string Phone { get; set; }
		public string Address { get; set; }
		public string TaxNumber { get; set; }
		public decimal CreditLimit { get; set; }
		public bool IsActive { get; set; }
		public DateTime CreatedAt { get; set; }
		public DateTime UpdatedAt { get; set; }
	}
}
