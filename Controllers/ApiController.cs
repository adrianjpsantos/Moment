using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moment.Data;
using Moment.Models.EntityDto;

namespace Moment.Controllers;

public class ApiController : Controller
{
    private readonly ApplicationDbContext _context;
    public ApiController (ApplicationDbContext context){
        this._context = context;
    }
    public IActionResult Index()
    {
        return View();
    }

    [HttpGet]
    [Route("api/categorias")]
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

