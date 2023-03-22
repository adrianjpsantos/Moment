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

    [Route("Pesquisa/{word}")]
    public IActionResult Search(string word)
    {
        return View();
    }
}
