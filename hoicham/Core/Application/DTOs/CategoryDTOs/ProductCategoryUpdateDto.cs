namespace hoicham.Core.Application.DTOs.CategoryDTOs
{
	public class ProductCategoryUpdateDto
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public string Code { get; set; }
		public string Description { get; set; }
		public Guid? ParentCategoryId { get; set; }
		public bool IsActive { get; set; }
	}
}
