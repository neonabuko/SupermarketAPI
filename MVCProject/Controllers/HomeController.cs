using System.Diagnostics;

using Microsoft.AspNetCore.Mvc;
using MVCProject.Components.Account;
using MVCProject.Models;


namespace MVCProject.Controllers;

public class HomeController(ILogger<HomeController> logger, ICategoriesEmailSender emailSender) : Controller
{
    private readonly ILogger<HomeController> _logger = logger;

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public async Task<IActionResult> Email()
    {
        await emailSender.SendEmailAsync("matheusventureli50@gmail.com", "Supermarket", "Hello, world");        
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}