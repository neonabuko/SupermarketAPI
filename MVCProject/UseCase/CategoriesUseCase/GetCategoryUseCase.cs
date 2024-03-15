using MVCProject.Models;
using MVCProject.Repository;
using MVCProject.UseCase.CategoriesUseCase.Interfaces;

namespace MVCProject.UseCase.CategoriesUseCase;

public class GetCategoryUseCase(ICategoryRepository categoryRepository) : IGetCategoryUseCase
{
    public async Task<CategoryDto> Get(int id)
    {
        return (await categoryRepository.GetAsync(id)).AsDto();
    }

    public Task<ICollection<Product>?> GetProducts(int id)
    {
        return Task.FromResult(categoryRepository.GetAsync(id).Result.Products);
    }
}