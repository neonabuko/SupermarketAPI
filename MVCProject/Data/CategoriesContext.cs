using System.Reflection;
using Microsoft.EntityFrameworkCore;
using MVCProject.Models;

namespace MVCProject.Data;

public class CategoriesContext(DbContextOptions<CategoriesContext> options) : DbContext(options)
{
    public DbSet<Category> Categories => Set<Category>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}