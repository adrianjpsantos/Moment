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
using System.Text.Json;

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
        public async Task<IActionResult> Index(string successMessage, string errorMessage)
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
                var setPhoneResult = await _userManager.SetPhoneNumberAsync(currentUser, model.PhoneUser);

                if (!setPhoneResult.Succeeded)
                {
                    errorMessage = "Erro inesperado ao tentar definir o número de telefone,";
                    return RedirectToAction("Index", model);
                }
            }

            await _signInManager.RefreshSignInAsync(currentUser);

            if (!String.IsNullOrEmpty(model.FirstName))
            {
                var userInfo = await _dbContext.UserInfos.FirstOrDefaultAsync(ui => ui.IdUser == currentUser.Id);

                _mapper.Map(model, userInfo);

                if (profilePicture != null)
                {
                    string wwwRootPath = _hostEnvironment.WebRootPath;

                    if (userInfo.ProfilePicture != null)
                    {
                        string oldFile = Path.Combine(wwwRootPath, userInfo.ProfilePicture.TrimStart('\\'));
                        if (System.IO.File.Exists(oldFile))
                        {
                            System.IO.File.Delete(oldFile);
                        }
                    }
                    string fileName = userInfo.IdUser + Path.GetExtension(profilePicture.FileName);
                    string uploads = Path.Combine(wwwRootPath, @"img\usersPictures");
                    string newFile = Path.Combine(uploads, fileName);
                    using (var stream = new FileStream(newFile, FileMode.Create))
                    {
                        profilePicture.CopyTo(stream);
                    }
                    userInfo.ProfilePicture = @"\img\usersPictures\" + fileName;
                }

                _dbContext.Update(userInfo);
                await _dbContext.SaveChangesAsync();
            }

            successMessage = "Seu perfil foi atualizado";

            var temp = new UserManagerIndexView();
            temp.SuccessMessage = successMessage;
            temp.ErrorMessage = errorMessage;
            return RedirectToAction("Index", new { errorMessage = errorMessage, successMessage = successMessage });
        }

        [HttpGet, Authorize, Route("Conta/MeusEventos")]
        public async Task<IActionResult> MyEvents()
        {
            UserManagerMyEventsView viewModel = new();
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
  
            viewModel.IsPromoter = isPromoter;
            viewModel.Conventions = conventions;
            return View(viewModel);
        }

        [HttpGet, Authorize, Route("/Conta/CompletarRegistro")]
        public IActionResult CompleteRegister()
        {
            return View();
        }

        [HttpGet, Authorize, Route("/Conta/Dados")]
        public IActionResult UserData()
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
                return BadRequest();
            }

        }

        [HttpPost, Authorize, Route("Conta/BaixarDados")]
        public async Task<IActionResult> DownloadPersonalData()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            // Only include personal data for download
            var personalData = new Dictionary<string, object>();
            var personalDataProps = typeof(IdentityUser).GetProperties().Where(
                            prop => Attribute.IsDefined(prop, typeof(PersonalDataAttribute)));
            foreach (var p in personalDataProps)
            {
                personalData.Add(p.Name, p.GetValue(user)?.ToString() ?? "null");
            }

            var logins = await _userManager.GetLoginsAsync(user);
            foreach (var l in logins)
            {
                personalData.Add($"{l.LoginProvider} external login provider key", l.ProviderKey);
            }

            var userInfo = await _dbContext.UserInfos.FirstOrDefaultAsync(ui => ui.IdUser == user.Id);
            if(userInfo != null){
                var infos = new UserInfoDto();
                _mapper.Map(userInfo,infos);
                personalData.Add("MoreInfos", infos);
            }

            personalData.Add($"Authenticator Key", await _userManager.GetAuthenticatorKeyAsync(user));

            Response.Headers.Add("Content-Disposition", "attachment; filename=PersonalData.json");
            return new FileContentResult(JsonSerializer.SerializeToUtf8Bytes(personalData), "application/json");
        }

        [HttpGet, Authorize, Route("Conta/DeletarDados")]
        public IActionResult DeletePersonalData(string id)
        {
            return View();
        }

        [HttpGet, Authorize, Route("Conta/ConfirmarDeletarDados")]
        public async Task<IActionResult> ConfirmDeletePersonalData()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            var result = await _userManager.DeleteAsync(user);
            var userId = await _userManager.GetUserIdAsync(user);
            if (!result.Succeeded)
            {
                throw new InvalidOperationException($"Unexpected error occurred deleting user.");
            }

            await _signInManager.SignOutAsync();

            return Redirect("~/");
        }
    }


}