using hoicham.Core.Ports.Output.Services;

// giờ mới chỉ gi log còn thực tế phải dùng prometheus.net
// package prometheus-net
namespace hoicham.Adapter.Secondary.Service
{
	public class MetricsService : IMetricsService
	{
		private readonly ILogger<MetricsService> _logger;

		public MetricsService(ILogger<MetricsService> logger)
		{
			_logger = logger;
		}

		public async Task RecordStockLevelAsync(Guid productId, int quantity)
		{
			_logger.LogInformation($"Recording stock level: Product: {productId}, Quantity: {quantity}");
			await Task.CompletedTask;
		}

		public async Task RecordTransactionAsync(Guid productId, int quantity, string type)
		{
			_logger.LogInformation($"Recording transaction: Product: {productId}, Quantity: {quantity}, Type: {type}");
			await Task.CompletedTask;
		}
	}
}
