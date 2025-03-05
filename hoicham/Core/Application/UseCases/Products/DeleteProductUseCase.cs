using hoicham.Core.Application.DTOs;
using hoicham.Core.Application.Services;
using hoicham.Core.Domain.Common;
using hoicham.Core.Ports.Input;
using hoicham.Core.Ports.Output.Services;

namespace hoicham.Core.Application.UseCases.Products
{
	public class DeleteProductUseCase
	{
		private readonly IProductDomainService _productService;
		private readonly ILoggerService _logger;

		public DeleteProductUseCase(IProductDomainService productService, ILoggerService logger)
		{
			_productService = productService;
			_logger = logger;
		}

		public async Task<Result> ExecuteAsync(Guid productId)
		{
			_logger.LogInformation($"Starting DeleteProduct: {productId}");

			// Gọi service để xóa sản phẩm
			var result = await _productService.DeleteProductAsync(productId);
			if (!result.IsSuccess)
			{
				_logger.LogError(null, $"Failed to delete product: {result.Error}");
				return result;
			}

			_logger.LogInformation("DeleteProduct completed successfully");
			return Result.Success();
		}
	}
}