using Microsoft.EntityFrameworkCore;
using MVC04.Data;
using MVC04.Models;

namespace MVC04.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly ProductDbContext _context;

    public ProductRepository(ProductDbContext context)
    {
        _context = context;
    }

    public Task<List<Product>> GetAllAsync()
    {
        return _context.Products
            .OrderBy(product => product.ProductID)
            .ToListAsync();
    }

    public async Task AddAsync(Product product)
    {
        product.ProductName = product.ProductName?.Trim() ?? string.Empty;
        product.ImageURL = product.ImageURL?.Trim() ?? string.Empty;
        product.Description = product.Description?.Trim();

        _context.Products.Add(product);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int productId)
    {
        var product = await _context.Products.FindAsync(productId);

        if (product is not null)
        {
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }
    }

    public Task<bool> ProductIdExistsAsync(int productId) =>
        _context.Products.AnyAsync(product => product.ProductID == productId);
}
