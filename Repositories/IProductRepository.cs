using MVC04.Models;

namespace MVC04.Repositories;

public interface IProductRepository
{
    Task<List<Product>> GetAllAsync();
    Task AddAsync(Product product);
    Task DeleteAsync(int productId);
    Task<bool> ProductIdExistsAsync(int productId);
}
