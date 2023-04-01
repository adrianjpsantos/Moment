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

    [Route("P/{texto}")]
    public async Task<IActionResult> Search(string texto, string city)
    {
        ViewData["Pesquisa"] = texto;
        ViewData["Title"] = $"Pesquisa - {texto}";
        var conventions = new List<Convention>();

        if (city != string.Empty && city != null)
            conventions = await _context.Conventions.Where(c => c.CityAndState() == city).ToListAsync();
        else
            conventions = await _context.Conventions.ToListAsync();


        var cities = await _context.Cities.ToListAsync();

        var searchView = new EventSearchView();
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

        List<CategoryDto> response = _mapper.Map<List<ConventionCategory>, List<CategoryDto>>(conventionCategories);

        return Json(response);
    }

}
