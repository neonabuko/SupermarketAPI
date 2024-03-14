using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using MVCProject.Components.Account;
using MVCProject.Models;
using MVCProject.Repository;
using MVCProject.UseCase;
using MVCProject.UseCase.CategoriesUseCase;
using MVCProject.UseCase.Interfaces;
using MVCProject.UseCase.ProductsUseCase;
using MVCProject.UseCase.ProductsUseCase.Interfaces;

namespace MVCProject.Data;

public static class DataExtensions
{
    public static async Task InitializeDbAsync(this IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<SupermarketContext>();
        await dbContext.Database.MigrateAsync();
    }

    public static IServiceCollection ConfigureServices(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString =  configuration.GetConnectionString("CategoriesContext");
        services.AddSqlServer<SupermarketContext>(connectionString)
            .AddScoped<ICategoryRepository, CategoryRepository>()
            .AddScoped<IProductRepository, ProductRepository>();

        services.AddTransient<ICategoriesEmailSender, CategoriesEmailSender>();
        
        services.AddTransient<ICreateCategoryUseCase, CreateCategoryUseCase>();
        services.AddTransient<IDeleteCategoryUseCase, DeleteCategoryUseCase>();
        services.AddTransient<IUpdateCategoryUseCase, UpdateCategoryUseCase>();
        services.AddTransient<IGetCategoryUseCase, GetCategoryUseCase>();
        services.AddTransient<IGetAllCategoriesUseCase, GetAllCategoriesUseCase>();
        services.AddTransient<IGetAllProductsUseCase, GetAllProductsUseCase>();
        services.AddTransient<IGetProductUseCase, GetProductUseCase>();
        services.AddTransient<ICreateProductUseCase, CreateProductUseCase>();
        services.AddTransient<IUpdateProductUseCase, UpdateProductUseCase>();
        services.AddTransient<IDeleteProductUseCase, DeleteProductUseCase>();
        services.AddTransient<IGetAllProductsInCategoryUseCase, GetAllProductsInCategoryUseCase>();
        
        services.AddScoped<CreateCategoryUseCase>();
        services.AddScoped<DeleteCategoryUseCase>();
        services.AddScoped<UpdateCategoryUseCase>();
        services.AddScoped<GetCategoryUseCase>();
        services.AddScoped<GetAllCategoriesUseCase>();
        services.AddScoped<GetAllProductsUseCase>();
        services.AddScoped<GetProductUseCase>();
        services.AddScoped<CreateProductUseCase>();
        services.AddScoped<UpdateProductUseCase>();
        services.AddScoped<DeleteProductUseCase>();
        services.AddScoped<GetAllProductsInCategoryUseCase>();
        
        services.AddRazorPages();
        
        services.AddRazorComponents()
            .AddInteractiveServerComponents();
        services.AddControllersWithViews();
        services.AddEndpointsApiExplorer();

        services.AddSwaggerGen();
        return services;
    }
}