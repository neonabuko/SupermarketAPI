namespace MVCProject.UseCase.ProductsUseCase.Interfaces;

public interface IGetAllProductsInCategoryUseCase
{
    Task<ICollection<ProductDto>> GetAllAsync(int categoryId);
}