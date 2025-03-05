namespace hoicham.Core.Application.DTOs.CategoryDTOs
{
	public class ProductCategoryCreateDto
	{
		public string Name { get; set; }
		public string Code { get; set; }
		public string Description { get; set; }
		public Guid? ParentCategoryId { get; set; }
		public bool IsActive { get; set; }
	}
}
