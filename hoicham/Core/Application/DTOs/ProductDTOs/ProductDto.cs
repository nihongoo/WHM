namespace hoicham.Core.Application.DTOs.ProductDTOs
{
    public class ProductDto
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal BasePrice { get; set; }
        public int MinimumStock { get; set; }
        public int MaximumStock { get; set; }
        public string SKU { get; set; }
        public string Barcode { get; set; }
        public Guid SupplierId { get; set; }
        public string SupplierName { get; set; }
        public Guid CategoryId { get; set; }
        public string CategoryName { get; set; }
        public Guid UnitId { get; set; }
        public string UnitName { get; set; }
        public bool AllowNegativeStock { get; set; }
        public string Specifications { get; set; }
        public decimal Weight { get; set; }
        public decimal Volume { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public Guid CreatedById { get; set; }
        public Guid UpdatedById { get; set; }
    }
}
