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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Unique key contrainst in product code
            modelBuilder.Entity<Products>()
                .HasIndex(p => p.ProductCode)
                .IsUnique();
            //Unique key contrainst in ProductGroupCode
            modelBuilder.Entity<ProductGroup>()
                .HasIndex(p => p.ProductGroupCode)
                .IsUnique();

            //foreign key contrainst
            modelBuilder.Entity<Products>()
                .HasOne(p => p.ProductGroup)
                .WithMany(pg => pg.Products)
                .HasForeignKey(pg => pg.ProductGroupID);
        }

    }
}
