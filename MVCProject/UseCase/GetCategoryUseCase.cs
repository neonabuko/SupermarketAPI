using MVCProject.Models;
using MVCProject.Repository;
using MVCProject.UseCase.Interfaces;

namespace MVCProject.UseCase;

public class GetCategoryUseCase(ICategoryRepository categoryRepository) : IGetCategoryUseCase
{
    public async Task<CategoryDto> Get(int id)
    {
        return (await categoryRepository.GetAsync(id)).AsDto();
    }
}