using MVCProject.Models;

namespace MVCProject.UseCase.ProductsUseCase.Interfaces;

public interface IGetProductUseCase
{ 
    Task<ProductDto> GetAsync(int id);
}