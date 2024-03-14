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
    public async Task<IActionResult> Index(int categoryId, string categoryName)
    {
        var products = (await productRepository.GetAllAsync())
            .Where(product => product.CategoryId == categoryId)
            .Select(product => product.AsDto())
            .ToList();
        ViewData["CategoryName"] = categoryName;
        ViewData["CategoryId"] = categoryId;
        return View(products);
    }

    [HttpGet]
    [Route("/products/add")]
    public async Task<IActionResult> Add(string categoryName, int categoryId)
    {
        ViewBag.Action = "Add";
        ViewData["CategoryName"] = categoryName;
        ViewData["CategoryId"] = categoryId;
        return await Task.FromResult<IActionResult>(View());
    }

    [HttpPost]
    [Route("/products/add")]
    public async Task<IActionResult> Add([FromForm] ProductDto productDto, [FromForm] int categoryId, 
        [FromForm] string categoryName)
    {
        Product newProduct = new()
        {
            Name = productDto.Name,
            Price = productDto.Price
        };
        ViewBag.Action = "add";
        ViewData["CategoryId"] = categoryId;
        ViewData["CategoryName"] = categoryName;
        newProduct.Category = await categoryRepository.GetAsync(categoryId);
        await productRepository.CreateAsync(newProduct);

        return RedirectToAction("Index", "Products", 
            new { categoryId = categoryId, categoryName = categoryName });
    }
}