using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moment.Data;
using Moment.Models.Entity;
using Moment.Models.EntityDto;

namespace Moment.Controllers;

public class EventController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly IWebHostEnvironment _hostEnvironment;
    private readonly IMapper _mapper;
    private UserManager<IdentityUser> _userManager;

    public EventController(UserManager<IdentityUser> userManager, ApplicationDbContext context, IWebHostEnvironment hostEnvironment, IMapper mapper)
    {
        this._context = context;
        this._hostEnvironment = hostEnvironment;
        this._userManager = userManager;
        this._mapper = mapper;
    }
    [Route("SejaUmProdutor")]
    public IActionResult BecomeAProducer()
    {
        return View();
    }

    [HttpGet]
    [Route("Pesquisa")]
    public async Task<IActionResult> Search(string texto, string local, string categoria, int valor)
    {
        var conventions = await _context.Conventions.Where(c => c.Name.Contains(texto)).ToListAsync();
        var cities = await _context.Cities.ToListAsync();
        var conventionCategories = await _context.ConventionCategories.ToListAsync();

         var categories = new List<CategoryDto>();
        foreach (var item in conventionCategories)
        {
            categories.Add(new CategoryDto(item));
        }

        if (!String.IsNullOrEmpty(local))
        {
            conventions = conventions.Where(c => c.CityAndState() == local).ToList();
        }

        if (!String.IsNullOrEmpty(categoria))
        {
            var cat = await _context.ConventionCategories.Where(cc => cc.Name == categoria).FirstOrDefaultAsync();
            conventions = conventions.Where(c => c.IdCategory == cat.Id).ToList();
        }

        var searchView = new EventSearchView(texto, local != null ? local : "",categoria,valor);
        searchView.Categories = categories;
        searchView.AddCities(cities);
        searchView.CreateEventCards(conventions);
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

    [HttpGet]
    [Route("Evento/{id}")]
    public async Task<IActionResult> EventPage(string id)
    {
        Convention convention;
        if (id != "" || id != null)
        {
            convention = await _context.Conventions.Where(c => c.Id.ToString() == id).FirstAsync();
        }
        else convention = await _context.Conventions.FirstAsync();

        EventPageView eventPage = new();
        _mapper.Map(convention, eventPage);

        return View(eventPage);
    }

    //API GET'S
    [HttpGet]
    [Route("api/categories")]
    public async Task<IActionResult> Categories()
    {
        var conventionCategories = await _context.ConventionCategories.ToListAsync();

        List<CategoryDto> response = new List<CategoryDto>();
        foreach (var cc in conventionCategories)
        {
            response.Add(new CategoryDto(cc));
        }

        return Json(response);
    }


}
