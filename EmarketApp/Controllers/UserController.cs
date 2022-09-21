using EmarketApp.Core.Application.Interfaces.Services;
using EmarketApp.Core.Application.ViewModels.User;
using EmarketApp.Core.Application.Helpers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using WebApp.EmarketApp.Middlewares;

namespace EmarketApp.Controllers.UserController
{
    public class UserController : Controller
    {

        private readonly IUserService _userService;
        private readonly ValidateUserSession _validateUserSession;

        public UserController(IUserService userService, ValidateUserSession validateUserSession)
        {
            _userService = userService;
            _validateUserSession = validateUserSession;
        }

        public IActionResult Index()
        {
            if (_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { controller = "Home", action = "Index" });
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(LoginVm vm)
        {
            if (_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { controller = "Home", action = "Index" });
            }

            if (!ModelState.IsValid)
            {
                return View(vm);
            }

            UserVm userVM = await _userService.Login(vm);

            if(userVM != null)
            {
                HttpContext.Session.Set<UserVm>("user", userVM); //Objeto guardado en la seccion
                return RedirectToRoute(new { controller = "Home", action = "Index" });
            }
            else
            {
                ModelState.AddModelError("userValidation", "Datos incorrectos");
            }

            return View(vm);
        }


        public IActionResult LogOut()
        {
            HttpContext.Session.Remove("user");
            return RedirectToRoute(new { controller = "User", action = "Index" });

        }

        public IActionResult RegisterUser()
        {
            if (_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { controller = "Home", action = "Index" });
            }

            return View(new SaveUserVm());
        }

        [HttpPost]
        public async Task<IActionResult> RegisterUser(SaveUserVm vm)
        {
            if (_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { controller = "Home", action = "Index" });
            }

            if (!ModelState.IsValid)
            {
                return View(vm);
            }

            try
            {
                await _userService.Add(vm);
                return RedirectToRoute(new { controller = "User", action = "Index" });
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("UserNameValidation", "Nombre de usuario ya esta en uso");
            }

            return View(vm);

        }
    }
}
