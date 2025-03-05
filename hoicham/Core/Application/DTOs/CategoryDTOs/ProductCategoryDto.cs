﻿namespace hoicham.Core.Application.DTOs.CategoryDTOs
{
	public class ProductCategoryDto
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public string Code { get; set; }
		public string Description { get; set; }
		public Guid? ParentCategoryId { get; set; }
		public string ParentCategoryName { get; set; } 
		public bool IsActive { get; set; }
		public DateTime CreatedAt { get; set; }
		public DateTime UpdatedAt { get; set; }
	}
}
