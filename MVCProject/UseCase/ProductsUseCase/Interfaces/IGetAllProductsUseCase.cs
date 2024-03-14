using MVCProject.Models;

namespace MVCProject.UseCase.ProductsUseCase.Interfaces;

public interface IGetAllProductsUseCase
{
    Task<List<ProductDto>> GetAll();
}