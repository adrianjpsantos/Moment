using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Moment.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Identity;
using Moment.Models.Entity;
using AutoMapper;
using Moment.Models.EntityDto;

namespace Moment.Controllers;

public class AdminController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly IWebHostEnvironment _hostEnvironment;
    private readonly IMapper _mapper;
    private UserManager<IdentityUser> _userManager;

    public AdminController(UserManager<IdentityUser> userManager, ApplicationDbContext context, IWebHostEnvironment hostEnvironment, IMapper mapper)
    {
        this._context = context;
        this._hostEnvironment = hostEnvironment;
        this._userManager = userManager;
        this._mapper = mapper;
    }

    public IActionResult Index()
    {
        return View();
    }
    [Route("/Conta/CompletarRegistro")]
    [HttpGet,Authorize]
    public IActionResult CompleteRegister()
    {
        return View();
    }
    

    [Route("/Conta/CompletarRegistro")]
    [HttpPost,Authorize]
    public IActionResult CompleteRegister(UserInfoDto info)
    {
        if(ModelState.IsValid){
            var userInfo = new UserInfo();
            userInfo.IdUser = _userManager.GetUserId(User);
            userInfo.Promoter = true;
            _mapper.Map(info,userInfo);
            _context.Add(userInfo);
            //return View(info);
            return RedirectToAction("CreateEvent","Admin");
        }
        return NotFound();
    }

    [Route("Eventos/Criar")]
    [Authorize]
    public IActionResult CreateEvent()
    {
        if (!UserIsPromoter())
            return RedirectToAction("CompleteRegister", "Admin");

        ViewData["CategoryList"] = new SelectList(_context.ConventionCategories.OrderBy(g => g.Id).ToList(), "Id", "Name");
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    [Route("Eventos/Criar")]
    public async Task<IActionResult> CreateEvent(EventCreateView eventCreate, IFormFile thumbnailPath, IFormFile backgroundPath)
    {
        ViewData["CategoryList"] = new SelectList(_context.ConventionCategories.OrderBy(g => g.Id).ToList(), "Id", "Name");
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

            var ct = new City(convention.CityAddress, convention.StateAddress);
            if (!_context.Cities.ToList().Contains(ct))
                _context.Add(ct);

            await _context.SaveChangesAsync();

            return RedirectToAction("CreatedEvent", convention);
        }
        return View();
    }

    [Authorize]
    public IActionResult CreatedEvent(Convention convention)
    {
        ViewData["NameEvent"] = convention.Name;
        ViewData["IdEvent"] = convention.Id;
        return View();
    }

    public bool UserIsPromoter()
    {
        var id = _userManager.GetUserId(User);
        var user = _context.UserInfos.Where(ui => ui.IdUser == id).FirstOrDefault();

        if (user != null && user.Promoter)
            return true;

        return false;
    }
}


