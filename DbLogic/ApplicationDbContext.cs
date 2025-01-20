using Microsoft.EntityFrameworkCore;
using Product.Models;

namespace Product.DbLogic
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }
        public DbSet<Products> products { get; set; } // DbSet for products
        public DbSet<ProductGroup> productGroups { get; set; }

    }
}
