namespace hoicham.Core.Application.DTOs.ProductDTOs
{
    public class ProductImageDto
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public string ImageUrl { get; set; }
        public string ThumbnailUrl { get; set; }
        public bool IsPrimary { get; set; }
        public int SortOrder { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
