using Emarket.Infrastructure.Persistence.Contexts;
using EmarketApp.Core.Application.Interfaces.Services;
using EmarketApp.Core.Application.Services;
using EmarketApp.Core.Application.ViewModels.Anuncios;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.EmarketApp.Middlewares;

namespace EmarketApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAnuncioService _anuncioService;
        private readonly ICategoryService _categoryService;
        private readonly ValidateUserSession _validateUserSession;

        public HomeController(IAnuncioService anuncioService, ICategoryService categoryService, ValidateUserSession validateUserSession)
        {
            _anuncioService = anuncioService;
            _categoryService = categoryService;
            _validateUserSession = validateUserSession;
        }

        public async Task<IActionResult> Index(FilterAnuncioVm vm)
        {
            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { controller = "User", action = "Index" });
            }

            ViewBag.Categories = await _categoryService.GetAllVm();
            return View( await _anuncioService.GetAllVmWithFilter(vm));
        }

        public async Task<IActionResult> Details(int Id)
        {
            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { controller = "User", action = "Index" });
            }

            await _anuncioService.GetByIdSaveVmInclude(Id);
            return View(await _anuncioService.GetByIdSaveVmInclude(Id));
        }


    }
}
