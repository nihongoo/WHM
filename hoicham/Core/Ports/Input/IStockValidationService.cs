namespace hoicham.Core.Ports.Input
{
    public interface IStockValidationService
    {
        Task<bool> ValidateStockLevelAsync(Guid productId, int quantity);
        Task<bool> ValidateWarehouseCapacityAsync(Guid warehouseId, int additionalQuantity);
    }
}
