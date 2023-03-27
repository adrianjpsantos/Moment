using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moment.Data;
using Moment.Models.Entity;
using Moment.Models.EntityDto;

namespace Moment.Controllers;

public class EventController : Controller
{
    private readonly ApplicationDbContext _context;
    public EventController(ApplicationDbContext context)
    {
        _context = context;
    }
    public IActionResult Index()
    {
        return View();
    }

    [Route("P/{texto}")]
    public async Task<IActionResult> Search(string texto)
    {
        ViewData["Pesquisa"] = texto;
        ViewData["Title"] = $"Pesquisa - {texto}";
        var cities = await _context.Cities.ToListAsync();
        var searchView = new EventSearchView(cities);
        return View(searchView);
    }


    [HttpGet]
    [Route("C/{category}")]
    public async Task<IActionResult> SearchCategory(string category)
    {
        ConventionCategory? conventionCategory = await _context.ConventionCategories.Where(cc => cc.Name.ToLower() == category.ToLower()).FirstOrDefaultAsync();

        if (conventionCategory != null)
        {
            var conventions = await _context.Conventions.Where(c => c.IdCategory == conventionCategory.Id).ToListAsync();
            var eventCards = new List<EventCard>();

            foreach (var convention in conventions)
            {
                eventCards.Add(new EventCard(convention));
            }

            CategoryView categoryView = new CategoryView(new CategoryDto(conventionCategory), eventCards);

            return View(categoryView);
        }

        return NotFound();
    }

    //API GET'S
    [HttpGet]
    [Route("api/categories")]
    public async Task<IActionResult> Categories()
    {
        var conventionCategories = await _context.ConventionCategories.ToListAsync();
        var response = new List<CategoryDto>();
        foreach (var cc in conventionCategories)
        {
            response.Add(new CategoryDto(cc));
        }

        return Json(response);
    }

}
