using MVCProject.Models;
using MVCProject.Repository;
using MVCProject.UseCase.ProductsUseCase.Interfaces;

namespace MVCProject.UseCase.ProductsUseCase;

public class UpdateProductUseCase(IProductRepository repository) : IUpdateProductUseCase
{
    public async Task UpdateAsync(int id, ProductDto productDto)
    {
        var toUpdate = await repository.GetAsync(id);
        
        toUpdate.Name = productDto.Name;
        toUpdate.Price = productDto.Price;
        
        await repository.UpdateAsync(id, toUpdate);
    }
}