using MVCProject.Models;
using MVCProject.Repository;
using MVCProject.UseCase.ProductsUseCase.Interfaces;

namespace MVCProject.UseCase.ProductsUseCase;

public class GetProductUseCase(IProductRepository productRepository) : IGetProductUseCase
{
    public Task<ProductDto> GetAsync(int id)
    {
        return Task.FromResult(productRepository.GetAsync(id).Result.AsDto());
    }
}