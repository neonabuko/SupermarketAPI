namespace MVCProject.UseCase.Interfaces;

public interface IGetAllCategoriesUseCase
{
    Task<List<CategoryDto>> GetAll();
}