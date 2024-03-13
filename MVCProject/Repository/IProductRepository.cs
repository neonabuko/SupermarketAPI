using MVCProject.Models;

namespace MVCProject.Repository;

public interface IProductRepository
{
    Task<Product> GetAsync(int id);
    Task<List<Product>> GetAllAsync();
    Task CreateAsync(Product product);
    Task Update(int id, Product product);
    Task Delete(int id);
}