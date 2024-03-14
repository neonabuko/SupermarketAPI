using Microsoft.AspNetCore.Mvc;
using MVCProject.UseCase.Interfaces;

namespace MVCProject.Controllers;

[ApiController]
[Route("/categories")]
public class CategoriesController(
    ICreateCategoryUseCase createCategory, 
    IDeleteCategoryUseCase deleteCategory,
    IUpdateCategoryUseCase updateCategory, 
    IGetCategoryUseCase getCategory, 
    IGetAllCategoriesUseCase getAllCategories
    ) : Controller
{
    [HttpGet]
    [Route("/categories/index")]
    public async Task<IActionResult> Index()
    {
        var categories = await getAllCategories.GetAll();
        return await Task.FromResult<IActionResult>(View(categories));
    }
    
    [HttpGet]
    public async Task<IActionResult> Edit(int? id)
    {
        ViewBag.Action = "edit";
        var category = await getCategory.Get(id ?? 0);
        return await Task.FromResult<IActionResult>(View(category));
    }
    
    [HttpPost]
    public async Task<IActionResult> Edit([FromForm] CategoryDto categoryDto)
    {
        ViewBag.Action = "edit";
        await updateCategory.Update(categoryDto);
        return await Task.FromResult<IActionResult>(RedirectToAction(nameof(Index)));
    }
    
    [HttpGet]
    [Route("/categories/delete")]
    public async Task<IActionResult> Delete(int id)
    {
        await deleteCategory.Delete(id);
        return RedirectToAction(nameof(Index));
    }
    
    [HttpGet]
    [Route("/categories/add")]
    public Task<IActionResult> Add()
    {
        ViewBag.Action = "Add";
        return Task.FromResult<IActionResult>(View());
    }
    
    [HttpPost]
    [Route("/categories/add")]
    public async Task<IActionResult> Add([FromForm] CategoryDto categoryDto)
    {
        if (!ModelState.IsValid) return View(categoryDto);
        
        await createCategory.Create(categoryDto);
        
        return RedirectToAction(nameof(Index));
    }
}