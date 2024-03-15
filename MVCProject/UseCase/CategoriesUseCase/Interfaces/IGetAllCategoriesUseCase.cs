namespace MVCProject.UseCase.CategoriesUseCase.Interfaces;

public interface IGetAllCategoriesUseCase
{
    Task<List<CategoryDto>> GetAll();
}