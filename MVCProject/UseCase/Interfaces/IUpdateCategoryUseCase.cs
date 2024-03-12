using MVCProject.Models;

namespace MVCProject.UseCase.Interfaces;

public interface IUpdateCategoryUseCase
{
    Task Update(CategoryDto categoryDto);
}