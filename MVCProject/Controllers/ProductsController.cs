using Microsoft.AspNetCore.Mvc;
using MVCProject.Models;
using MVCProject.Repository;
using MVCProject.UseCase.ProductsUseCase.Interfaces;

namespace MVCProject.Controllers;

[ApiController]
[Route("/products")]
public class ProductsController(
    IGetProductUseCase getProductUseCase,
    IGetAllProductsInCategoryUseCase getAllProductsInCategoryUseCase,
    ICreateProductUseCase createProductUseCase,
    IUpdateProductUseCase updateProductUseCase,
    IDeleteProductUseCase deleteProductUseCase
    ) : Controller
{
    [HttpGet]
    [Route("/products/index")]
    public async Task<IActionResult> Index(int categoryId, string categoryName)
    {
        var products = await getAllProductsInCategoryUseCase.GetAllAsync(categoryId);
        ViewData["CategoryName"] = categoryName;
        ViewData["CategoryId"] = categoryId;
        return View(products);
    }

    [HttpGet]
    [Route("/products/get-products/{categoryId:int}")]
    public async Task<ICollection<ProductDto>> GetProducts(int categoryId)
    {
        var products = await getAllProductsInCategoryUseCase.GetAllAsync(categoryId);
        return products;
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
    public async Task<IActionResult> Add(
        [FromForm] ProductDto productDto, 
        [FromForm] int categoryId, 
        [FromForm] string categoryName
        )
    {
        ViewBag.Action = "add";
        ViewData["CategoryId"] = categoryId;
        ViewData["CategoryName"] = categoryName;
        await createProductUseCase.CreateAsync(productDto, categoryId);

        return RedirectToAction("Index", "Products", new { categoryId, categoryName });
    }

    [HttpGet]
    [Route("/products/delete")]
    public async Task<IActionResult> Delete(int productId, int categoryId, string categoryName)
    {
        await deleteProductUseCase.DeleteAsync(productId);
        return RedirectToAction("Index", "Products", new { categoryId, categoryName });
    }
    
    [HttpGet]
    public async Task<IActionResult> Edit(int productId, int categoryId, string categoryName)
    {
        ViewBag.Action = "edit";
        ViewData["CategoryId"] = categoryId;
        ViewData["CategoryName"] = categoryName;
        var product = await getProductUseCase.GetAsync(productId);
        return await Task.FromResult<IActionResult>(View(product));
    }
    
    [HttpPost]
    public async Task<IActionResult> Edit(
        [FromForm] ProductDto productDto,
        [FromForm] int categoryId, [FromForm] string categoryName
        )
    {
        ViewBag.Action = "edit";
        ViewData["CategoryId"] = categoryId;
        ViewData["CategoryName"] = categoryName;
        await updateProductUseCase.UpdateAsync(productDto.Id, productDto);
        return RedirectToAction("Index", "Products", new { categoryId, categoryName });
    }
}