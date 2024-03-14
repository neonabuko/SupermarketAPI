using MVCProject.Models;

namespace MVCProject.Repository;

public interface IProductRepository
{
    Task<Product> GetAsync(int id);
    Task<List<Product>> GetAllAsync();
    Task CreateAsync(Product product);
    Task UpdateAsync(int id, Product product);
    Task DeleteAsync(int id);
}