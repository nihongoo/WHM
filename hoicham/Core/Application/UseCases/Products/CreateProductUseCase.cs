using hoicham.Core.Application.DTOs;
using hoicham.Core.Application.DTOs.ProductDTOs;
using hoicham.Core.Application.Services;
using hoicham.Core.Domain.Common;
using hoicham.Core.Ports.Input;
using hoicham.Core.Ports.Output.Services;

namespace hoicham.Core.Application.UseCases.Products
{
	public class CreateProductUseCase
	{
		private readonly IProductDomainService _productService;
		private readonly ILoggerService _logger;

		public CreateProductUseCase(IProductDomainService productService, ILoggerService logger)
		{
			_productService = productService;
			_logger = logger;
		}

		public async Task<Result> ExecuteAsync(ProductCreateDto request, Guid userId)
		{
			_logger.LogInformation($"Starting CreateProduct: {request.Name}");

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

			// Gọi service để tạo sản phẩm
			var result = await _productService.CreateProductAsync(request.Name, request.Description, request.BasePrice, request.InitialStock);
			if (!result.IsSuccess)
			{
				_logger.LogError(null, $"Failed to create product: {result.Error}");
				return result;
			}

			_logger.LogInformation("CreateProduct completed successfully");
			return Result.Success();
		}
	}
}