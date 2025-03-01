namespace hoicham.Core.Domain.Events.ErrorEvents
{
    public class InventoryOperationFailedEvent : DomainEvent
    {
        public Guid ProductId { get; }
        public string Operation { get; }
        public string Reason { get; }

        public InventoryOperationFailedEvent(
            Guid productId,
            string operation,
            string reason)
        {
            ProductId = productId;
            Operation = operation;
            Reason = reason;
        }
    }
}
