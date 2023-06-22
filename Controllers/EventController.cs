using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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

    [HttpGet, Route("Pesquisa")]
    public async Task<IActionResult> Search(string texto, string local, string categoria, int valor)
    {
        var conventions = texto == null ? await _context.Conventions.ToListAsync() : await _context.Conventions.Where(c => c.Name.Contains(texto == null ? "" : texto)).ToListAsync();
        var cities = await _context.Cities.ToListAsync();
        var conventionCategories = await _context.ConventionCategories.ToListAsync();

        conventions = conventions.OrderByDescending(c => c.CreateDate).ToList();

        if (!String.IsNullOrEmpty(local))
        {
            conventions = conventions.Where(c => c.CityAndState.Contains(local)).ToList();
        }

        if (!String.IsNullOrEmpty(categoria))
        {
            var cat = await _context.ConventionCategories.Where(cc => cc.Name == categoria).FirstOrDefaultAsync();
            conventions = conventions.Where(c => c.IdCategory == cat.Id).ToList();
        }

        if (valor > 0)
        {
            var isFree = valor == 1 ? true : false;
            conventions = conventions.Where(c => c.IsFree == isFree).ToList();
        }

        var searchView = new EventSearchView(texto, local != null ? local : "", categoria, valor);
        searchView.CreateEventCards(conventions);
        searchView.Cities = cities;
        searchView.Categories = new SelectList(_context.ConventionCategories.OrderBy(g => g.Id).ToList(), "Name", "Name", searchView.Categoria);

        return View(searchView);
    }



    [HttpGet, Authorize, Route("Evento/CriarEvento")]
    public IActionResult CreateEvent()
    {
        if (!UserIsPromoter())
            return RedirectToAction("CompleteRegister", "UserManager");

        var eventCreate = new EventCreateView();
        eventCreate.Categories = new SelectList(_context.ConventionCategories.OrderBy(g => g.Id).ToList(), "Id", "Name");
        return View(eventCreate);
    }

    [HttpPost, ValidateAntiForgeryToken, Route("Evento/CriarEvento")]
    public async Task<IActionResult> CreateEvent(EventCreateView eventCreate, IFormFile thumbnailPath, IFormFile backgroundPath)
    {

        if (ModelState.IsValid)
        {
            Console.WriteLine(eventCreate);
            if (thumbnailPath != null)
            {
                string wwwRootPath = _hostEnvironment.WebRootPath;
                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(thumbnailPath.FileName);
                string uploads = Path.Combine(wwwRootPath, @"img\eventThumb");
                string newFile = Path.Combine(uploads, fileName);
                using (var stream = new FileStream(newFile, FileMode.Create))
                {
                    thumbnailPath.CopyTo(stream);
                }
                eventCreate.ThumbnailPath = @"\img\eventThumb\" + fileName;
            }

            if (backgroundPath != null)
            {
                string wwwRootPath = _hostEnvironment.WebRootPath;
                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(backgroundPath.FileName);
                string uploads = Path.Combine(wwwRootPath, @"img\eventBack");
                string newFile = Path.Combine(uploads, fileName);
                using (var stream = new FileStream(newFile, FileMode.Create))
                {
                    backgroundPath.CopyTo(stream);
                }
                eventCreate.BackgroundPath = @"\img\eventBack\" + fileName;
            }

            var convention = new Convention();
            convention.IdUserPromoter = _userManager.GetUserId(User);
            convention.CreateDate = DateTime.Now;

            _mapper.Map(eventCreate, convention);
            _context.Add(convention);


            await _context.SaveChangesAsync();

            return RedirectToAction("CreatedEvent", convention);
        }
        eventCreate.Categories = new SelectList(_context.ConventionCategories.OrderBy(g => g.Id).ToList(), "Id", "Name");
        return View(eventCreate);
    }

    [HttpGet, Authorize, Route("Evento/CriadoComSucesso")]
    public IActionResult CreatedEvent(Convention convention)
    {
        EventCreatedView view = new EventCreatedView();

        view.NameEvent = convention.Name;
        view.IdEvent = convention.Id.ToString();
        return View(view);
    }

    [HttpGet, Authorize, Route("Evento/{id}/Editar")]
    public async Task<IActionResult> EditEvent(string id)
    {
        var convention = await _context.Conventions.Where(c => c.Id.ToString() == id).FirstAsync();
        if (convention == null) return NotFound();

        EventEditView viewModel = new();
        _mapper.Map(convention, viewModel);

        viewModel.Categories = new SelectList(_context.ConventionCategories.OrderBy(g => g.Id).ToList(), "Id", "Name", convention.IdCategory);

        return View(viewModel);
    }

    [HttpPost, ValidateAntiForgeryToken, Route("Evento/{id}/Editar")]
    public async Task<IActionResult> EditEvent(EventEditView eventEdit, IFormFile thumbnailPath, IFormFile backgroundPath)
    {
        if (ModelState.IsValid)
        {
            Console.WriteLine(eventEdit);
            if (thumbnailPath != null)
            {
                string wwwRootPath = _hostEnvironment.WebRootPath;

                if (eventEdit.ThumbnailPath != null)
                {
                    string oldFile = Path.Combine(wwwRootPath, eventEdit.ThumbnailPath.TrimStart('\\'));
                    if (System.IO.File.Exists(oldFile))
                    {
                        System.IO.File.Delete(oldFile);
                    }
                }

                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(thumbnailPath.FileName);
                string uploads = Path.Combine(wwwRootPath, @"img\eventThumb");
                string newFile = Path.Combine(uploads, fileName);
                using (var stream = new FileStream(newFile, FileMode.Create))
                {
                    thumbnailPath.CopyTo(stream);
                }
                eventEdit.ThumbnailPath = @"\img\eventThumb\" + fileName;
            }

            if (backgroundPath != null)
            {
                string wwwRootPath = _hostEnvironment.WebRootPath;


                if (eventEdit.BackgroundPath != null)
                {
                    string oldFile = Path.Combine(wwwRootPath, eventEdit.BackgroundPath.TrimStart('\\'));
                    if (System.IO.File.Exists(oldFile))
                    {
                        System.IO.File.Delete(oldFile);
                    }
                }
                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(backgroundPath.FileName);
                string uploads = Path.Combine(wwwRootPath, @"img\eventBack");
                string newFile = Path.Combine(uploads, fileName);
                using (var stream = new FileStream(newFile, FileMode.Create))
                {
                    backgroundPath.CopyTo(stream);
                }
                eventEdit.BackgroundPath = @"\img\eventBack\" + fileName;
            }

            var convention = await _context.Conventions.Where(c => c.Id.ToString() == eventEdit.Id).FirstAsync();
            convention.IdUserPromoter = _userManager.GetUserId(User);
            convention.CreateDate = DateTime.Now;

            _mapper.Map(eventEdit, convention);
            _context.Update(convention);

            var ct = new City(convention.CityAddress, convention.StateAddress);
            if (!_context.Cities.ToList().Contains(ct))
                _context.Add(ct);

            await _context.SaveChangesAsync();

            return RedirectToAction("EventPage", new { id = convention.Id });
        }
        eventEdit.Categories = new SelectList(_context.ConventionCategories.OrderBy(g => g.Id).ToList(), "Id", "Name", eventEdit.IdCategory);
        return View(eventEdit);
    }


    [HttpGet, Authorize, Route("Evento/{id}/Deletar")]
    public IActionResult DeleteEvent(string id)
    {
        var convention = _context.Conventions.FirstOrDefault(c => c.Id.ToString() == id);

        if (convention == null)
            return BadRequest();

        ViewData["Title"] = $"Deletar Evento - {convention.Name}";
        ViewData["Name"] = convention.Name;
        ViewData["Id"] = convention.Id;
        ViewData["thumbPath"] = convention.ThumbnailPath;
        return View();
    }

    [HttpGet, Authorize, Route("Evento/{id}/ConfirmarDeletar")]
    public async Task<IActionResult> Delete(string id)
    {
        var convention = await _context.Conventions.FirstOrDefaultAsync(c => c.Id.ToString() == id);

        if (convention == null)
            return BadRequest();


        _context.Remove(convention);

        await _context.SaveChangesAsync();
        return RedirectToAction("MyEvents", "UserManager");

    }

    public bool UserIsPromoter()
    {
        var id = _userManager.GetUserId(User);
        var user = _context.UserInfos.Where(user => user.IdUser == id).FirstOrDefault();

        if (user != null && user.Promoter)
            return true;

        return false;
    }


    [HttpGet, Route("Categoria/{category}")]
    public async Task<IActionResult> SearchCategory(string category, string cidade)
    {
        ConventionCategory? conventionCategory = await _context.ConventionCategories.Where(cc => cc.Name.ToLower() == category.ToLower()).FirstOrDefaultAsync();
        ViewData["Cities"] = cidade != null ? new SelectList(_context.Cities.ToList(), "CityAndState", "CityAndState", cidade) : new SelectList(_context.Cities.ToList(), "CityAndState", "CityAndState");
        if (conventionCategory != null)
        {
            var conventions = await _context.Conventions.Where(c => c.IdCategory == conventionCategory.Id).ToListAsync();
            if (cidade != null)
                conventions = conventions.Where(c => c.CityAndState.Contains(cidade)).ToList();
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


        if (convention != null)
        {
            eventPage.UserInfo = await _context.UserInfos.Where(ui => ui.IdUser == convention.IdUserPromoter).FirstOrDefaultAsync();
            eventPage.Conventions = await _context.Conventions.Where(c => c.IdUserPromoter == convention.IdUserPromoter).OrderByDescending(c => c.StartDate).Take(10).ToListAsync();
        }

        return View(eventPage);
    }
}
