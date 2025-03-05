using hoicham.Core.Application.DTOs;
using hoicham.Core.Application.DTOs.ProductDTOs;
using hoicham.Core.Application.Services;
using hoicham.Core.Domain.Common;
using hoicham.Core.Ports.Input;
using hoicham.Core.Ports.Output.Services;

namespace hoicham.Core.Application.UseCases.Products
{
	public class UpdateProductUseCase
	{
		private readonly IProductDomainService _productService;
		private readonly ILoggerService _logger;

		public UpdateProductUseCase(IProductDomainService productService, ILoggerService logger)
		{
			_productService = productService;
			_logger = logger;
		}

		public async Task<Result> ExecuteAsync(ProductUpdateDto request, Guid userId)
		{
			_logger.LogInformation($"Starting UpdateProduct: {request.Id}");

			// Validate input
			if (string.IsNullOrWhiteSpace(request.Code))
			{
				_logger.LogWarning("Invalid product code: Code must not be empty");
				return Result.Failure("Product code must not be empty");
			}

			if (string.IsNullOrWhiteSpace(request.Name))
			{
				_logger.LogWarning("Invalid product name: Name must not be empty");
				return Result.Failure("Product name must not be empty");
			}

			// Gọi service để cập nhật sản phẩm
			var result = await _productService.UpdateProductAsync(request, userId);
			if (!result.IsSuccess)
			{
				_logger.LogError(null, $"Failed to update product: {result.Error}");
				return result;
			}

			_logger.LogInformation("UpdateProduct completed successfully");
			return Result.Success();
		}
	}
}