using MVCProject.Models;

namespace MVCProject.Repository;

public interface ICategoryRepository
{
    Task CreateAsync(Category category);
    Task<List<Category>> GetAllAsync();
    Task<Category> GetAsync(int id);
    Task UpdateAsync(int id, Category category);
    Task DeleteAsync(int id);
}