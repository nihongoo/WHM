namespace hoicham.Core.Ports.Output.Services
{
    public interface IMetricsService
    {
        Task RecordStockLevelAsync(Guid productId, int quantity);
        Task RecordTransactionAsync(Guid productId, int quantity, string type);
    }
}
