using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CRUDelicious.Models;

namespace CRUDelicious.Controllers;

public class DishController : Controller
{
    private readonly ILogger<DishController> _logger;

    private MyContext _context;

    public DishController(ILogger<DishController> logger, MyContext context)
    {
        _logger  = logger;
        _context = context;
    }

    //---------- ROUTES ----------

    [HttpGet("dishes/new")]
    public ViewResult NewDish() => View();

    [HttpPost("dishes/create")]
    public IActionResult CreateDish(Dish newDish)
    {
        if (!ModelState.IsValid) return View("NewDish");
        
        _context.Add(newDish);
        _context.SaveChanges();
        return RedirectToAction("Index", "Home");
    }

    [HttpGet("dishes/{dishId}")]
    public IActionResult ViewDish(int dishId)
    {
        Dish? SingleDish = _context.Dishes.FirstOrDefault(d => d.DishId == dishId);
        if (SingleDish == null)
        {
            return RedirectToAction("Index");
        }
        return View("ViewDish", SingleDish);
    }

    [HttpPost("dishes/{dishId}/delete")]
    public RedirectToActionResult DeleteDish(int dishId)
    {
        Dish? ToBeDeleted = _context.Dishes.SingleOrDefault(d => d.DishId == dishId);
        if (ToBeDeleted != null)
        {
            _context.Remove(ToBeDeleted);
            _context.SaveChanges();
        }
        return RedirectToAction("Index", "Home");
    }

    [HttpGet("dishes/{dishId}/edit")]
    public IActionResult EditDish (int dishId)
    {
        Dish? SingleDish = _context.Dishes.FirstOrDefault(d => d.DishId == dishId);
        if (SingleDish == null)
        {
            return RedirectToAction("Index");
        }
        return View("EditDish", SingleDish);
    }

    [HttpPost("dishes/{dishId}/update")]
    public IActionResult UpdateDish (int dishId, Dish editedDish)
    {
        Dish? OldDish = _context.Dishes.FirstOrDefault(d => d.DishId == dishId);
        if (!ModelState.IsValid)
        {
            return View("EditDish", editedDish);
            // return View("EditDish", OldDish); // this version (along with value tags in our form) will reset values upon invalid edit
        }
        OldDish.Name        = editedDish.Name;
        OldDish.Chef        = editedDish.Chef;
        OldDish.Tastiness   = editedDish.Tastiness;
        OldDish.Calories    = editedDish.Calories;
        OldDish.Description = editedDish.Description;
        OldDish.UpdatedAt   = DateTime.Now;
        _context.SaveChanges();
        // return RedirectToAction("Index", "Home");
        return RedirectToAction("ViewDish", new{dishId}); // dishId = dishId
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}