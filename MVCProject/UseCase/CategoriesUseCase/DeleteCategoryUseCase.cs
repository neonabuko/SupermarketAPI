using MVCProject.Repository;
using MVCProject.UseCase.Interfaces;

namespace MVCProject.UseCase;

public class DeleteCategoryUseCase(ICategoryRepository categoryRepository, IProductRepository productRepository) : IDeleteCategoryUseCase
{
    public async Task Delete(int id)
    {
        var products = productRepository
            .GetAllAsync()
            .Result
            .Where(product => product.CategoryId == id);
        foreach (var product in products)
        {
            await productRepository.DeleteAsync(product.Id);
        }
        await categoryRepository.DeleteAsync(id);
    }
}