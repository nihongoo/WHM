using hoicham.Core.Ports.Output.Services;

// chưa cài smpt
namespace hoicham.Adapter.Secondary.Service
{
	public class NotificationService : INotificationService
	{
		private readonly ILogger<NotificationService> _logger;

		public NotificationService(ILogger<NotificationService> logger)
		{
			_logger = logger;
		}

		public async Task SendLowStockAlertAsync(Guid productId, int currentStock, int threshold)
		{
			_logger.LogInformation("Sending low stock alert for product {ProductId}: Current stock {CurrentStock} is below threshold {Threshold}",
				productId, currentStock, threshold);

			await Task.CompletedTask; // Placeholder for async operation
		}

		public async Task SendStockUpdateNotificationAsync(Guid productId, int oldQuantity, int newQuantity)
		{
			_logger.LogInformation("Sending stock update notification for product {ProductId}: {OldQuantity} -> {NewQuantity}",
				productId, oldQuantity, newQuantity);

			await Task.CompletedTask; // Placeholder for async operation
		}
	}
}
