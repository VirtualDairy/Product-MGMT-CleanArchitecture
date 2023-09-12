using Microsoft.EntityFrameworkCore;
using ProductMgmt.Core;

namespace ProductMgmt.Infrastructure
{
    internal class ProductContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "ProductMgmtDb");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.Code);
                entity.Property(e => e.Name).IsRequired();
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => new { e.Code, e.SubCategoryCode });
                entity.Property(e => e.SubCategoryCode).IsRequired();
            });
        }
    }
}
