namespace MVCProject.UseCase.Interfaces;

public interface IDeleteCategoryUseCase
{
    Task Delete(int id);
}