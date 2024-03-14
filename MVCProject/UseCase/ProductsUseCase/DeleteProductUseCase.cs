using MVCProject.Repository;
using MVCProject.UseCase.ProductsUseCase.Interfaces;

namespace MVCProject.UseCase.ProductsUseCase;

public class DeleteProductUseCase(IProductRepository repository) : IDeleteProductUseCase
{
    public async Task DeleteAsync(int id)
    {
        await repository.DeleteAsync(id);
    }
}