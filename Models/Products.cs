using System.ComponentModel.DataAnnotations.Schema;

namespace Product.Models
{
    public class Products
    {
        [Column("ProductID")]
        public int ID { get; set; }
        public required string ProductName { get; set; }
        public required  string ProductCode { get; set; }
        public string? ProductDescription { get; set; }
        public decimal Price { get; set; }
        public decimal Quantity { get; set; } = 0;
        public int ProductGroupID { get; set; }
        public ProductGroup ProductGroup { get; set; }
    }
}
