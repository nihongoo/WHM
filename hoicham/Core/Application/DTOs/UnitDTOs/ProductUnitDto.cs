namespace hoicham.Core.Application.DTOs.UnitDTOs
{
	public class ProductUnitDto
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public string Abbreviation { get; set; }
		public string Description { get; set; }
		public bool IsActive { get; set; }
		public DateTime CreatedAt { get; set; }
	}
}
