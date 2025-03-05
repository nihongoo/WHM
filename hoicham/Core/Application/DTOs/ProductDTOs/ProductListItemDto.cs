namespace hoicham.Core.Application.DTOs.ProductDTOs
{
    public class ProductListItemDto
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public decimal BasePrice { get; set; }
        public string SKU { get; set; }
        public string CategoryName { get; set; }
        public string UnitName { get; set; }
        public bool IsActive { get; set; }
    }
}
