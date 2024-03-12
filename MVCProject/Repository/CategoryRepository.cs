using Microsoft.EntityFrameworkCore;
using MVCProject.Data;
using MVCProject.Models;

namespace MVCProject.Repository;

public class CategoryRepository(CategoriesContext dbContext) : ICategoryRepository
{
    public async Task CreateAsync(Category category)
    {
        await dbContext.Categories.AddAsync(category);
        await dbContext.SaveChangesAsync();
    }

    public async Task<List<Category>> GetAllAsync()
    {
        return await dbContext.Categories.AsNoTracking().ToListAsync();
    }

    public async Task<Category> GetAsync(int id)
    {
        return await dbContext.Categories.FindAsync(id) ?? throw new Exception();
    }

    public async Task UpdateAsync(int id, Category category)
    {
        var toUpdate = await dbContext.Categories.FindAsync(id);
        if (toUpdate != null)
        {
            toUpdate.Name = category.Name;
            toUpdate.Description = category.Description;
            dbContext.Update(toUpdate);
        }

        await dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        await dbContext.Categories.Where(category => category.Id == id).ExecuteDeleteAsync();
    }
}