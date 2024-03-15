namespace MVCProject.UseCase.CategoriesUseCase.Interfaces;

public interface IUpdateCategoryUseCase
{
    Task Update(CategoryDto categoryDto);
}