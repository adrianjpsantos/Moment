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

    [HttpGet, Authorize, Route("/Conta/CompletarRegistro")]
    public IActionResult CompleteRegister()
    {
        return View();
    }



    [HttpPost, Authorize, Route("/Conta/CompletarRegistro")]
    public async Task<IActionResult> CompleteRegisterAsync(UserInfoDto info, IFormFile profilePicture)
    {
        if (ModelState.IsValid)
        {
            var userInfo = new UserInfo();
            _mapper.Map(info, userInfo);

            userInfo.IdUser = _userManager.GetUserId(User);
            userInfo.Promoter = true;

            if (profilePicture != null)
            {
                string wwwRootPath = _hostEnvironment.WebRootPath;
                string fileName = userInfo.IdUser + Path.GetExtension(profilePicture.FileName);
                string uploads = Path.Combine(wwwRootPath, @"img\usersPictures");
                string newFile = Path.Combine(uploads, fileName);
                using (var stream = new FileStream(newFile, FileMode.Create))
                {
                    profilePicture.CopyTo(stream);
                }
                userInfo.ProfilePicture = @"\img\usersPictures\" + fileName;
            }

            _context.UserInfos.Add(userInfo);
            await _context.SaveChangesAsync();
            //return View(info);
            return RedirectToAction("Index", "Event");
        }
        else
        {
            return Json(info);
        }

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
        var user =  _context.UserInfos.Where(user => user.IdUser == id).FirstOrDefault();

        if (user != null && user.Promoter)
            return true;

        return false;
    }
}


