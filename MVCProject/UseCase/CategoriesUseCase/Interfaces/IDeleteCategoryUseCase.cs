namespace MVCProject.UseCase.CategoriesUseCase.Interfaces;

public interface IDeleteCategoryUseCase
{
    Task Delete(int id);
}