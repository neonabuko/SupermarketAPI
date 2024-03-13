using Microsoft.AspNetCore.Mvc;
using MVCProject.Models;
using MVCProject.Repository;

namespace MVCProject.Controllers;

[ApiController]
[Route("/products")]
public class ProductsController(
    ICategoryRepository categoryRepository, 
    IProductRepository productRepository
    ) : Controller
{
    [HttpGet]
    [Route("/products/index")]
    public async Task<IActionResult> Index(int categoryId)
    {
        var products = await productRepository.GetAllAsync();
        return View(products);
    }

    [HttpGet]
    [Route("/products/add")]
    public Task<IActionResult> Add()
    {
        ViewBag.Action = "Add";
        return Task.FromResult<IActionResult>(View());
    }

    [HttpPost]
    [Route("/products/add")]
    public async Task<IActionResult> Add(int categoryId, ProductDto productDto)
    {
        var category = await categoryRepository.GetAsync(categoryId);
        
        Product newProduct = new()
        {
            Name = productDto.Name,
            Price = productDto.Price
        };
        
        await productRepository.CreateAsync(newProduct);
        
        category.Products?.Add(newProduct);
        await categoryRepository.UpdateAsync(categoryId, category);
        
        return RedirectToAction(nameof(Index));
    }
}