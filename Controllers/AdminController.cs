using System.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Moment.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using Moment.Models.Dto;

namespace Moment.Controllers;

public class AdminController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly IWebHostEnvironment _hostEnvironment;

    public AdminController(ApplicationDbContext context, IWebHostEnvironment hostEnvironment)
    {
        this._context = context;
        this._hostEnvironment = hostEnvironment;
    }

    public IActionResult Index()
    {
        return View();
    }

    [Route("Eventos/Criar")]
    [Authorize]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(EventCreateView eventCreate, IFormFile thumbnailFile, IFormFile backgroundFile)
    {
        ViewData["CategoryId"] = new SelectList(_context.ConventionCategories.OrderBy(g => g.Id), "Id", "Name");
        if (ModelState.IsValid)
        {
            if (thumbnailFile != null)
            {
                string wwwRootPath = _hostEnvironment.WebRootPath;
                string fileName = new Guid().ToString() + Path.GetExtension(thumbnailFile.FileName);
                string uploads = Path.Combine(wwwRootPath, @"img\eventThumb");
                string newFile = Path.Combine(uploads, fileName);
                using (var stream = new FileStream(newFile, FileMode.Create))
                {
                    thumbnailFile.CopyTo(stream);
                }
                eventCreate.ThumbnailPath = @"\img\eventThumb\" + fileName;
            }

            if (backgroundFile != null)
            {
                string wwwRootPath = _hostEnvironment.WebRootPath;
                string fileName = new Guid().ToString() + Path.GetExtension(backgroundFile.FileName);
                string uploads = Path.Combine(wwwRootPath, @"img\eventThumb");
                string newFile = Path.Combine(uploads, fileName);
                using (var stream = new FileStream(newFile, FileMode.Create))
                {
                    backgroundFile.CopyTo(stream);
                }
                eventCreate.BackgroundPath = @"\img\eventBack\" + fileName;
            }

            _context.Add(eventCreate);
            await _context.SaveChangesAsync();

            return RedirectToAction("Created");
        }
        return View();
    }

    [Authorize]
    public IActionResult Created()
    {
        return View();
    }
}


