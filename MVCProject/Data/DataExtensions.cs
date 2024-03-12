using System.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MVCProject.Repository;
using MVCProject.UseCase;
using MVCProject.UseCase.Interfaces;

namespace MVCProject.Data;

public static class DataExtensions
{
    public static async Task InitializeDbAsync(this IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<CategoriesContext>();
        await dbContext.Database.MigrateAsync();
    }

    public static IServiceCollection AddRepositories(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        var connectionString =  configuration.GetConnectionString("CategoriesContext");
        services.AddSqlServer<CategoriesContext>(connectionString).AddScoped<ICategoryRepository, CategoryRepository>();
        
        services.AddTransient<ICreateCategoryUseCase, CreateCategoryUseCase>();
        services.AddTransient<IDeleteCategoryUseCase, DeleteCategoryUseCase>();
        services.AddTransient<IUpdateCategoryUseCase, UpdateCategoryUseCase>();
        services.AddTransient<IGetCategoryUseCase, GetCategoryUseCase>();
        services.AddTransient<IGetAllCategoriesUseCase, GetAllCategoriesUseCase>();
        
        services.AddScoped<CreateCategoryUseCase>();
        services.AddScoped<DeleteCategoryUseCase>();
        services.AddScoped<UpdateCategoryUseCase>();
        services.AddScoped<GetCategoryUseCase>();
        services.AddScoped<GetAllCategoriesUseCase>();
        
        services.AddRazorPages();
        services.AddIdentity<IdentityUser, IdentityRole>()
            .AddEntityFrameworkStores<CategoriesContext>()
            .AddDefaultTokenProviders();

        return services;
    }
}