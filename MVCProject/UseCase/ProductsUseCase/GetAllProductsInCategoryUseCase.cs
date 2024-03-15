using MVCProject.Models;
using MVCProject.Repository;
using MVCProject.UseCase.ProductsUseCase.Interfaces;

namespace MVCProject.UseCase.ProductsUseCase;

public class GetAllProductsInCategoryUseCase(IProductRepository productRepository) : IGetAllProductsInCategoryUseCase
{
    public async Task<ICollection<ProductDto>> GetAllAsync(int categoryId)
    {
        return (await productRepository.GetAllAsync())
            .Where(product => product.CategoryId == categoryId)
            .Select(product => product.AsDto())
            .ToList();
    }
}