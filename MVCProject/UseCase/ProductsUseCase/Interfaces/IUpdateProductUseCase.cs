namespace MVCProject.UseCase.ProductsUseCase.Interfaces;

public interface IUpdateProductUseCase
{
    Task UpdateAsync(int id, ProductDto productDto);
}