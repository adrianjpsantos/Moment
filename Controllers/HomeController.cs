using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Moment.Data;
using Moment.Models;
using Moment.Models.Entity;
using Moment.Models.EntityDto;

namespace Moment.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ApplicationDbContext _context;
    public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var conventionCategories = await _context.ConventionCategories.ToListAsync();
        var categories = new List<CategoryDto>();
        foreach (var item in conventionCategories)
        {
            categories.Add(new CategoryDto(item));
        }
        var homeIndex = new HomeIndexView(categories);
        return View(homeIndex);
    }

    [HttpPost]
    public async Task<IActionResult> Index(HomeIndexView homeIndexView)
    {

        if (ModelState.IsValid)
        {
            return RedirectToAction("Search", "Event", homeIndexView.searchForm);
        }

        var conventionCategories = await _context.ConventionCategories.ToListAsync();
        var categories = new List<CategoryDto>();
        foreach (var item in conventionCategories)
        {
            categories.Add(new CategoryDto(item));
        }
        var homeIndex = new HomeIndexView(categories);
        return View(homeIndex);
        return View(homeIndex);
    }

    [Route("Privacidade")]
    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }



    [Route("Ajuda")]
    public IActionResult CenterHelp()
    {
        return View();
    }
}
