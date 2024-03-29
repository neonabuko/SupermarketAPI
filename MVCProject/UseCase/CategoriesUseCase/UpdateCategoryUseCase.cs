using MVCProject.Repository;
using MVCProject.UseCase.CategoriesUseCase.Interfaces;

namespace MVCProject.UseCase.CategoriesUseCase;

public class UpdateCategoryUseCase(ICategoryRepository categoryRepository) : IUpdateCategoryUseCase
{
    public async Task Update(CategoryDto categoryDto)
    {
        var category = await categoryRepository.GetAsync(categoryDto.Id);
        
        category.Name = categoryDto.Name;
        category.Description = categoryDto.Description;
        
        await categoryRepository.UpdateAsync(categoryDto.Id, category);
    }
}