namespace hoicham.Core.Domain.Events.TransactionEvents
{
    public class InventoryTransactionCreatedEvent : DomainEvent
    {
        public Guid TransactionId { get; }
        public Guid ProductId { get; }
        public int Quantity { get; }
        public string TransactionType { get; }
        public DateTime TransactionDate { get; }

        public InventoryTransactionCreatedEvent(
            Guid transactionId,
            Guid productId,
            int quantity,
            string transactionType,
            DateTime transactionDate)
        {
            TransactionId = transactionId;
            ProductId = productId;
            Quantity = quantity;
            TransactionType = transactionType;
            TransactionDate = transactionDate;
        }
    }
}
