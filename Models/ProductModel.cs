using Microsoft.EntityFrameworkCore;
using MVC04.Data;

namespace MVC04.Models;

public class ProductModel
{
    private readonly ProductDbContext _context;

    public ProductModel(ProductDbContext context)
    {
        _context = context;
    }

    public Task<List<Product>> GetProducts()
    {
        return _context.Products
            .OrderBy(product => product.ProductID)
            .ToListAsync();
    }

    public Task<Product?> GetProduct(int id)
    {
        return _context.Products
            .FirstOrDefaultAsync(product => product.ProductID == id);
    }
}
