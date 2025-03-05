﻿namespace hoicham.Core.Application.DTOs.ResponseDTOs
{
	public class PagedResultDto<T>
	{
		public List<T> Items { get; set; } = new List<T>();
		public int TotalCount { get; set; }
		public int PageIndex { get; set; }
		public int PageSize { get; set; }
		public int TotalPages => (int)Math.Ceiling(TotalCount / (double)PageSize);
		public bool HasPreviousPage => PageIndex > 1;
		public bool HasNextPage => PageIndex < TotalPages;
	}
}
