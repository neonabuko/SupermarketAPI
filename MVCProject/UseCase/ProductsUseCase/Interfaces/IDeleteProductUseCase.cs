namespace MVCProject.UseCase.ProductsUseCase.Interfaces;

public interface IDeleteProductUseCase
{
    Task DeleteAsync(int id);
}