using Microsoft.EntityFrameworkCore;
using MVCProject.Data;
using MVCProject.Models;

namespace MVCProject.Repository;

public class ProductRepository(SupermarketContext context) : IProductRepository
{
    public async Task<Product> GetAsync(int id)
    {
        return await context.Products.FindAsync(id) ?? throw new Exception();
    }

    public async Task<List<Product>> GetAllAsync()
    {
        return await context.Products.AsNoTracking().ToListAsync();
    }

    public async Task CreateAsync(Product product)
    {
        await context.Products.AddAsync(product);
        await context.SaveChangesAsync();
    }

    public async Task UpdateAsync(int id, Product product)
    {
        var toUpdate = await context.Products.FindAsync(id);
        if (toUpdate != null)
        {
            toUpdate.Name = product.Name;
            toUpdate.Price = product.Price;
            context.Update(toUpdate);
        }

        await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        await context.Products.Where(product => product.Id == id).ExecuteDeleteAsync();
    }
}