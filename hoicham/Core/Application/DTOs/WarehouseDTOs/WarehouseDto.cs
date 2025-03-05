﻿namespace hoicham.Core.Application.DTOs.WarehouseDTOs
{
	public class WarehouseDto
	{
		public Guid Id { get; set; }
		public string Code { get; set; }
		public string Name { get; set; }
		public string Address { get; set; }
		public string Phone { get; set; }
		public string Email { get; set; }
		public decimal TotalCapacity { get; set; }
		public decimal UsedCapacity { get; set; }
		public bool IsActive { get; set; }
		public DateTime CreatedAt { get; set; }
		public DateTime UpdatedAt { get; set; }
	}
}
