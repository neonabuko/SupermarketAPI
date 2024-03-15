using MVCProject.Models;
using MVCProject.Repository;
using MVCProject.UseCase.CategoriesUseCase.Interfaces;

namespace MVCProject.UseCase.CategoriesUseCase;

public class GetAllCategoriesUseCase(ICategoryRepository categoryRepository) : IGetAllCategoriesUseCase
{
    public async Task<List<CategoryDto>> GetAll()
    {
        return (await categoryRepository.GetAllAsync()).Select(category => category.AsDto()).ToList();
    }
}