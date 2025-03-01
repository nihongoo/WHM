namespace hoicham.Core.Ports.Output.Services
{
    public interface INotificationService
    {
        Task SendLowStockAlertAsync(Guid productId, int currentStock, int threshold);
        Task SendStockUpdateNotificationAsync(Guid productId, int oldQuantity, int newQuantity);
    }
}
