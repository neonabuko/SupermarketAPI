using Microsoft.AspNetCore.Mvc;
using MVCProject.UseCase.Interfaces;

namespace MVCProject.Controllers;

[ApiController]
[Route("/categories")]
public class CategoriesController(ICreateCategoryUseCase createCategoryUseCase, IDeleteCategoryUseCase deleteCategoryUseCase,
    IUpdateCategoryUseCase updateCategoryUseCase, IGetCategoryUseCase getCategoryUseCase, IGetAllCategoriesUseCase getAllCategoriesUseCase) : Controller
{
    [Route("/categories/index")]
    public Task<IActionResult> Index()
    {
        var categories = getAllCategoriesUseCase.GetAll().Result;
        return Task.FromResult<IActionResult>(View(categories));
    }
    
    public async Task<IActionResult> Edit(int? id)
    {
        ViewBag.Action = "edit";
        var category = await getCategoryUseCase.Get(id ?? 0);
        return await Task.FromResult<IActionResult>(View(category));
    }
    
    [HttpPost]
    public async Task<IActionResult> Edit([FromForm] CategoryDto categoryDto)
    {
        ViewBag.Action = "edit";
        await updateCategoryUseCase.Update(categoryDto);
        return await Task.FromResult<IActionResult>(RedirectToAction(nameof(Index)));
    }
    
    [Route("/categories/delete")]
    public async Task<IActionResult> Delete(int id)
    {
        await deleteCategoryUseCase.Delete(id);
        return RedirectToAction(nameof(Index));
    }
    
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
        
        await createCategoryUseCase.Create(categoryDto);
        
        return RedirectToAction(nameof(Index));
    }
}