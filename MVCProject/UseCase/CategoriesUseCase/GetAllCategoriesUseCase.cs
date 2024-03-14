using MVCProject.Models;
using MVCProject.Repository;
using MVCProject.UseCase.Interfaces;

namespace MVCProject.UseCase;

public class GetAllCategoriesUseCase(ICategoryRepository categoryRepository) : IGetAllCategoriesUseCase
{
    public async Task<List<CategoryDto>> GetAll()
    {
        return (await categoryRepository.GetAllAsync()).Select(category => category.AsDto()).ToList();
    }
}