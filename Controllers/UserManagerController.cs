using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moment.Data;
using Moment.Models.Entity;
using Moment.Models.EntityDto;

namespace Moment.Controllers
{

    public class UserManagerController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IWebHostEnvironment _hostEnvironment;
        private readonly IMapper _mapper;
        private UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        public UserManagerController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, ApplicationDbContext dbContext, IWebHostEnvironment hostEnvironment, IMapper mapper)
        {
            this._dbContext = dbContext;
            this._hostEnvironment = hostEnvironment;
            this._userManager = userManager;
            this._signInManager = signInManager;
            this._mapper = mapper;
        }
        [HttpGet, Authorize, Route("Conta")]
        public async Task<IActionResult> Index()
        {
            ViewData["Title"] = "Preferências";
            var user = await _userManager.GetUserAsync(User);
            var info = await _dbContext.UserInfos.Where(u => u.IdUser == _userManager.GetUserId(User)).FirstOrDefaultAsync();
            var model = new UserManagerIndexView();

            model.Username = user.UserName;
            model.Email = user.Email;
            model.Phone = user.PhoneNumber;

            if (info != null)
            {
                _mapper.Map(info, model);
            }

            return View(model);
        }


        [HttpPost, Authorize, Route("Conta")]
        public async Task<IActionResult> Index(UserManagerIndexView user, IFormFile profilePicture)
        {
            var StatusMessage = "";
            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (!ModelState.IsValid)
            {
                return View(user);
            }

            var phoneNumber = await _userManager.GetPhoneNumberAsync(currentUser);
            if (user.Phone != phoneNumber)
            {
                var setPhoneResult = await _userManager.SetPhoneNumberAsync(currentUser, user.Phone);
                if (!setPhoneResult.Succeeded)
                {
                    StatusMessage = "Erro inesperado ao tentar definir o número de telefone.";
                    return View(user);
                }
            }

            await _signInManager.RefreshSignInAsync(currentUser);

            if (!String.IsNullOrEmpty(user.FirstName))
            {
                var userInfo = new UserInfo();
                userInfo.Promoter = true;
                _mapper.Map(user, userInfo);
                
                _dbContext.Update(userInfo);
                await _dbContext.SaveChangesAsync();
            }
            StatusMessage = "Seu perfil foi atualizado";

            ModelState.AddModelError("", StatusMessage);
            return View(user);
        }

        [HttpGet, Authorize, Route("Conta/MeusEventos")]
        public async Task<IActionResult> MyEvents()
        {
            ViewData["Title"] = "Preferências";

            var conventions = new List<EventCard>();
            var idUser = _userManager.GetUserId(User);
            var userInfo = _dbContext.UserInfos.Where(u => u.IdUser == idUser).FirstOrDefault();
            bool isPromoter = userInfo != null ? userInfo.Promoter : false;
            var _conventions = _dbContext.Conventions.Where(c => c.IdUserPromoter == idUser).ToList();
            foreach (var convention in _conventions)
            {
                conventions.Add(new EventCard(convention));
            }

            ViewBag.IsPromoter = isPromoter;
            ViewData["Conventions"] = conventions;
            return View();
        }

        [HttpGet, Authorize, Route("/Conta/CompletarRegistro")]
        public IActionResult CompleteRegister()
        {
            return View();
        }



        [HttpPost, Authorize, Route("/Conta/CompletarRegistro")]
        public async Task<IActionResult> CompleteRegister(UserInfoDto info, IFormFile profilePicture)
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

                _dbContext.UserInfos.Add(userInfo);
                await _dbContext.SaveChangesAsync();
                //return View(info);
                return RedirectToAction("BecomeAProducer", "Event");
            }
            else
            {
                return Json(info);
            }

        }

    }
}