using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Moment.Controllers;

public class EventController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    [Route("Eventos/Criar")]
    public IActionResult Create()
    {
        return View();
    }

    public IActionResult Created()
    {
        return View();
    }

    [Route("P/{texto}")]
    public IActionResult Search(string texto,string cidade)
    {
        ViewData["Pesquisa"] = texto;
        ViewData["Title"] = $"Pesquisa - {texto}";
        return View();
    }

    [Route("C/{texto}")]
    public IActionResult SearchCategory(string texto)
    {
        ViewData["Pesquisa"] = texto;
        ViewData["Title"] = texto;
        return View();
    }

    
}
