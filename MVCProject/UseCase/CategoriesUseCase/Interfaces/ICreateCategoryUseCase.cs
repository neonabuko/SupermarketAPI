namespace MVCProject.UseCase.CategoriesUseCase.Interfaces;

public interface ICreateCategoryUseCase
{
    Task Create(CategoryDto categoryDto);
}