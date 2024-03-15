using MVCProject.Models;

namespace MVCProject.UseCase.CategoriesUseCase.Interfaces;

public interface IGetCategoryUseCase
{
    Task<CategoryDto> Get(int id);
    Task<ICollection<Product>?> GetProducts(int id);
}