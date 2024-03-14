using MVCProject.Models;
using MVCProject.Repository;
using MVCProject.UseCase.ProductsUseCase.Interfaces;

namespace MVCProject.UseCase.ProductsUseCase;

public class GetAllProductsUseCase(IProductRepository repository) : IGetAllProductsUseCase
{
    public async Task<List<ProductDto>> GetAll()
    {
        return (await repository.GetAllAsync()).Select(product => product.AsDto()).ToList();
    }
}