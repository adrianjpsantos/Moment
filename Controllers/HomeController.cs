using System.Diagnostics;
using AutoMapper;
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
    private readonly IMapper _mapper;
    public HomeController(ILogger<HomeController> logger, ApplicationDbContext context, IMapper mapper)
    {
        _mapper = mapper;
        _logger = logger;
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var conventions = _context.Conventions.OrderByDescending(c => c.CreateDate).Take(25).ToList();
        var conventionCategories = await _context.ConventionCategories.ToListAsync();
        var cities = await _context.Cities.ToListAsync();

        var categories = new List<CategoryDto>();

        foreach (var item in conventionCategories)
        {
            categories.Add(new CategoryDto(item));
        }

        var homeIndex = new HomeIndexView();

        homeIndex.StartCategory = categories[new Random().Next(categories.Count)];
        homeIndex.Cities = cities;
        homeIndex.Categories = new SelectList(_context.ConventionCategories.OrderBy(g => g.Id).ToList(), "Name", "Name");
        homeIndex.CreateRecentEvents(conventions);
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
