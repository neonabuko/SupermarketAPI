namespace MVCProject.UseCase.ProductsUseCase.Interfaces;

public interface IGetAllProductsInCategoryUseCase
{
    Task<List<ProductDto>> GetAllAsync(int categoryId);
}