using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CRUD_Delicious.Models;

namespace CRUD_Delicious.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private MyContext _context;

    public HomeController(ILogger<HomeController> logger, MyContext context)
    {
        _logger  = logger;
        _context = context;
    }

    [HttpGet("")]
    public ViewResult Index()
    {
        List<Dish> DishesFromDb = _context.Dishes.OrderBy(d => d.Name).ToList();
        return View("Index", DishesFromDb);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
