using MVCProject.Models;
using MVCProject.Repository;
using MVCProject.UseCase.Interfaces;

namespace MVCProject.UseCase.CategoriesUseCase;

public class CreateCategoryUseCase(ICategoryRepository categoryRepository) : ICreateCategoryUseCase
{
    public async Task Create(CategoryDto categoryDto)
    {
        Category category = new()
        {
            Name = categoryDto.Name,
            Description = categoryDto.Description
        };

        await categoryRepository.CreateAsync(category);
    }
}