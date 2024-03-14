using MVCProject.Models;
using MVCProject.Repository;
using MVCProject.UseCase.ProductsUseCase.Interfaces;

namespace MVCProject.UseCase.ProductsUseCase;

public class CreateProductUseCase(IProductRepository repository, ICategoryRepository categoryRepository) : ICreateProductUseCase
{
    public async Task CreateAsync(ProductDto productDto, int categoryId)
    {
        Product newProduct = new()
        {
            Name = productDto.Name,
            Price = productDto.Price,
            Category = await categoryRepository.GetAsync(categoryId)
        };
        await repository.CreateAsync(newProduct);
    }
}