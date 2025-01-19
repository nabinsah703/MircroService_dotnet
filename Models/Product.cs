namespace Product.Models
{
    public class Product
    {
        public int ID { get; set; }
        public string? ProductName { get; set; }
        public int ProductCount { get; set; }
        public string? ProductDescription { get; set; }
        public string? ProductCategoryID { get; set; }
        public decimal Price { get; set; }
        public decimal Quantity { get; set; } = 0;
    }
}
