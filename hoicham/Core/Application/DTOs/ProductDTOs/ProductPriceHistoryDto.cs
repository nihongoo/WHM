namespace hoicham.Core.Application.DTOs.ProductDTOs
{
    public class ProductPriceHistoryDto
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal OldPrice { get; set; }
        public decimal NewPrice { get; set; }
        public DateTime EffectiveDate { get; set; }
        public string Reason { get; set; }
        public Guid UpdatedById { get; set; }
        public string UpdatedByUserName { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
