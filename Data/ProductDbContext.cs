using Microsoft.EntityFrameworkCore;
using MVC04.Models;

namespace MVC04.Data;

public class ProductDbContext : DbContext
{
    public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options)
    {
    }

    public DbSet<Product> Products => Set<Product>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>().HasKey(product => product.ProductID);
        modelBuilder.Entity<Product>().Property(product => product.ProductID).ValueGeneratedNever();
        modelBuilder.Entity<Product>().Property(product => product.ProductName).HasMaxLength(100);
        modelBuilder.Entity<Product>().HasData(
            new Product { ProductID = 1, ProductName = "Sản phẩm A", ImageURL = "a.png", ProductPrice = 100000, Description = "Mô tả sản phẩm A" },
            new Product { ProductID = 2, ProductName = "Sản phẩm B", ImageURL = "b.png", ProductPrice = 200000, Description = "Mô tả sản phẩm B" },
            new Product { ProductID = 3, ProductName = "Sản phẩm C", ImageURL = "c.png", ProductPrice = 300000, Description = "Mô tả sản phẩm C" },
            new Product { ProductID = 4, ProductName = "Sản phẩm D", ImageURL = "d.png", ProductPrice = 400000, Description = "Mô tả sản phẩm D" },
            new Product { ProductID = 5, ProductName = "Sản phẩm E", ImageURL = "e.png", ProductPrice = 500000, Description = "Mô tả sản phẩm E" },
            new Product { ProductID = 6, ProductName = "Sản phẩm F", ImageURL = "f.png", ProductPrice = 600000, Description = "Mô tả sản phẩm F" },
            new Product { ProductID = 7, ProductName = "Sản phẩm G", ImageURL = "g.png", ProductPrice = 700000, Description = "Mô tả sản phẩm G" },
            new Product { ProductID = 8, ProductName = "Sản phẩm H", ImageURL = "h.png", ProductPrice = 800000, Description = "Mô tả sản phẩm H" },
            new Product { ProductID = 9, ProductName = "Sản phẩm I", ImageURL = "i.png", ProductPrice = 900000, Description = "Mô tả sản phẩm I" },
            new Product { ProductID = 10, ProductName = "Sản phẩm J", ImageURL = "j.png", ProductPrice = 1000000, Description = "Mô tả sản phẩm J" }
        );
    }
}
