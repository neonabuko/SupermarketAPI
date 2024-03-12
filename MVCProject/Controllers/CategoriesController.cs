using Microsoft.AspNetCore.Mvc;
using MVCProject.Models;
using MVCProject.Repository;

namespace MVCProject.Controllers;

[ApiController]
[Route("/categories")]
public class CategoriesController(ICategoryRepository repository) : Controller
{
    [Route("/categories/index")]
    public async Task<IActionResult> Index()
    {
        var categories = (await repository.GetAllAsync()).Select(category => category).ToList();
        return View(categories);
    }
    
    public async Task<IActionResult> Edit(int? id)
    {
        ViewBag.Action = "edit";
        var category = await repository.GetAsync(id ?? 0);
        return await Task.FromResult<IActionResult>(View(category));
    }
    
    [HttpPost]
    public async Task<IActionResult> Edit([FromForm]Category category)
    {
        ViewBag.Action = "edit";
        await repository.UpdateAsync(category.Id, category);
        return await Task.FromResult<IActionResult>(RedirectToAction(nameof(Index)));
    }
    
    [Route("/categories/delete")]
    public async Task<IActionResult> Delete(int id)
    {
        await repository.DeleteAsync(id);
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
    public async Task<IActionResult> Add([FromForm] Category category)
    {
        if (!ModelState.IsValid) return View(category);
        
        await repository.CreateAsync(category);
        return RedirectToAction(nameof(Index));
    }
}