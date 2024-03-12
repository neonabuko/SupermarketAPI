using MVCProject.Repository;
using MVCProject.UseCase.Interfaces;

namespace MVCProject.UseCase;

public class DeleteCategoryUseCase(ICategoryRepository categoryRepository) : IDeleteCategoryUseCase
{
    public async Task Delete(int id)
    {
        await categoryRepository.DeleteAsync(id);
    }
}