﻿using hoicham.Core.Application.DTOs.ProductDTOs;
using hoicham.Core.Domain.Common;

namespace hoicham.Core.Ports.Input
{
    public interface IProductDomainService
    {
        Task<Result> CreateProductAsync(string name, string description, decimal price, int initialStock);
        Task<Result> UpdateProductPriceAsync(Guid productId, decimal newPrice);
        Task<Result> UpdateProductAsync(ProductUpdateDto request, Guid userId);
        Task<Result> DeleteProductAsync(Guid productId);
	}
}
