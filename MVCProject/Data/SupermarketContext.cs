using System.Reflection;
using Microsoft.EntityFrameworkCore;
using MVCProject.Models;

namespace MVCProject.Data;

public class SupermarketContext(DbContextOptions<SupermarketContext> options) : DbContext(options)
{
    public DbSet<Category> Categories => Set<Category>();
    public DbSet<Product> Products => Set<Product>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}