﻿namespace hoicham.Core.Application.DTOs.SalesOrderDTOs
{
	public class SalesOrderItemCreateDto
	{
		public Guid ProductId { get; set; }
		public int Quantity { get; set; }
		public decimal UnitPrice { get; set; }
	}
}
