namespace MVCProject.UseCase.Interfaces;

public interface ICreateCategoryUseCase
{
    Task Create(CategoryDto categoryDto);
}