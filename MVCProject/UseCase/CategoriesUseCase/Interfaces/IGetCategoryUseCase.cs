namespace MVCProject.UseCase.Interfaces;

public interface IGetCategoryUseCase
{
    Task<CategoryDto> Get(int id);
}