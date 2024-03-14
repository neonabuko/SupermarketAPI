namespace MVCProject.UseCase.ProductsUseCase.Interfaces;

public interface ICreateProductUseCase
{
    Task CreateAsync(ProductDto productDto, int categoryId);
}