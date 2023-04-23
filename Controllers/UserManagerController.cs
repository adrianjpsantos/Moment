using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Moment.Controllers
{
    
    public class UserManagerController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        public UserManagerController(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult MyEvents()
        {
            return View();
        }
    }
}