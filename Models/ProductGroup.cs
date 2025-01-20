using System.ComponentModel.DataAnnotations.Schema;

namespace Product.Models
{
    public class ProductGroup
    {
        [Column("ProductGroupID")]
        public int ID { get; set; }
        public required string ProductGroupCode { get; set; }
        public required string ProductGroupName { get; set; }
        public string Remarks { get; set; } = string.Empty;
        public ICollection<Products> Products { get; set; }
    }
}
