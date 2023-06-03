using System.Reflection.Metadata;
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
        public async Task<IActionResult> Index(string successMessage,string errorMessage)
        {
            ViewData["Title"] = "Preferências";
            var currentUser = await _userManager.GetUserAsync(User);
            var info = await _dbContext.UserInfos.Where(u => u.IdUser == _userManager.GetUserId(User)).FirstOrDefaultAsync();
            var model = new UserManagerIndexView();

            model.NameUser = currentUser.UserName;
            model.EmailUser = currentUser.Email;
            model.PhoneUser = currentUser.PhoneNumber;
            model.ErrorMessage = errorMessage;
            model.SuccessMessage = successMessage;

            if (info != null)
            {
                _mapper.Map(info, model);
            }

            return View(model);
        }


        [HttpPost, Authorize, Route("/Conta/AtualizaInfos")]
        public async Task<IActionResult> UpdateUser(UserManagerIndexView user, IFormFile profilePicture)
        {
            var model = user;
            var successMessage = "";
            var errorMessage = "";
            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(new { Message = "Faltou Informações na requisição" });
            }

            var phoneNumber = await _userManager.GetPhoneNumberAsync(currentUser);
            if (model.PhoneUser != phoneNumber)
            {
                successMessage += "Numero diferente Telefone,";
                var setPhoneResult = await _userManager.SetPhoneNumberAsync(currentUser, model.PhoneUser);

                if (!setPhoneResult.Succeeded)
                {
                    errorMessage += "Erro inesperado ao tentar definir o número de telefone,";
                    return RedirectToAction("Index",model);
                }
                else
                {
                    successMessage += "Atualizou Telefone,";
                }
            }

            await _signInManager.RefreshSignInAsync(currentUser);

            if (!String.IsNullOrEmpty(model.FirstName))
            {
                var userInfo = new UserInfo();
                userInfo.IdUser = currentUser.Id;
                userInfo.Promoter = true;
                _mapper.Map(model, userInfo);

                _dbContext.Update(userInfo);
                await _dbContext.SaveChangesAsync();
            }

            successMessage += "  Seu perfil foi atualizado";

            var temp = new UserManagerIndexView();
            temp.SuccessMessage = successMessage;
            temp.ErrorMessage = errorMessage;
            return RedirectToAction("Index", new {errorMessage = errorMessage, successMessage = successMessage});
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