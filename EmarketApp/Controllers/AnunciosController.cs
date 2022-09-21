using EmarketApp.Core.Application.Interfaces.Services;
using EmarketApp.Core.Application.ViewModels.Anuncios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Threading.Tasks;
using WebApp.EmarketApp.Middlewares;

namespace EmarketApp.Controllers.Anuncios
{
    public class AnunciosController : Controller
    {
        private readonly IAnuncioService _anuncioService;
        private readonly ICategoryService _categoryService;      
        private readonly ValidateUserSession _validateUserSession;

        public AnunciosController(IAnuncioService anuncioService, ICategoryService categoryService,ValidateUserSession validateUserSession)
        {
            _anuncioService = anuncioService;
            _categoryService = categoryService;           
            _validateUserSession = validateUserSession;
        }

        public async Task<IActionResult> Index()
        {
            if ( !_validateUserSession.HasUser() )
            {
                return RedirectToRoute(new { controller = "User", action = "Index" });
            }

            return View(await _anuncioService.GetAllVm());
        }

        public async  Task<IActionResult> Create()
        {
            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { controller = "User", action = "Index" });
            }

            SaveAnuncioVm vm = new();
            vm.CategoriesList = await _categoryService.GetAllVm();
            return View("SaveAnuncios", vm);
        }

        [HttpPost]
        public async Task<IActionResult> Create(SaveAnuncioVm vm)
        {
            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { controller = "User", action = "Index" });
            }

            //validaciones
            if (!ModelState.IsValid)
            {
                vm.CategoriesList = await _categoryService.GetAllVm();
                return View("SaveAnuncios", vm);
            }

            SaveAnuncioVm saveAnuncio = await _anuncioService.Add(vm);

            if (saveAnuncio.Id != 0 && saveAnuncio != null)
            {
                saveAnuncio.ImgFile1 = UploadFile(vm.File1, saveAnuncio.Id);
                saveAnuncio.ImgFile2 = UploadFile(vm.File2, saveAnuncio.Id);
                saveAnuncio.ImgFile3 = UploadFile(vm.File3, saveAnuncio.Id);
                saveAnuncio.ImgFile4 = UploadFile(vm.File4, saveAnuncio.Id);

                await _anuncioService.Update(saveAnuncio);
            }


            return RedirectToRoute(new {controller="Anuncios", action="Index"});
        }

        public async Task<IActionResult> Edit(int Id)
        {
            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { controller = "User", action = "Index" });
            }

            SaveAnuncioVm vm = await _anuncioService.GetByIdSaveVm(Id);
            vm.CategoriesList = await _categoryService.GetAllVm();
            return View("SaveAnuncios", vm);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(SaveAnuncioVm vm)
        {
            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { controller = "User", action = "Index" });
            }
            //validaciones
            if (!ModelState.IsValid)
            {
                vm.CategoriesList = await _categoryService.GetAllVm();
                return View("SaveAnuncios", vm);
            }

            SaveAnuncioVm SaveVm = await _anuncioService.GetByIdSaveVm(vm.Id);

            vm.ImgFile1 = UploadFile(vm.File1, vm.Id, true, SaveVm.ImgFile1);
            vm.ImgFile2 = UploadFile(vm.File2, vm.Id, true, SaveVm.ImgFile2);
            vm.ImgFile3 = UploadFile(vm.File3, vm.Id, true, SaveVm.ImgFile3);
            vm.ImgFile4 = UploadFile(vm.File4, vm.Id, true, SaveVm.ImgFile4);

            await _anuncioService.Update(vm);

            return RedirectToRoute(new { controller = "Anuncios", action = "Index" });
        }

        public async Task<IActionResult> Delete(int Id)
        {
            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { controller = "User", action = "Index" });
            }

            return View( await _anuncioService.GetByIdSaveVm(Id));
        }

        [HttpPost]
        public async Task<IActionResult> DeletePost(int Id)
        {
            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { controller = "User", action = "Index" });
            }

            await _anuncioService.Delete(Id);

            //Get Directory path
            string basePath = $"/Img/Anuncios/{Id}";
            string path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot{basePath}");
            //Create folder if not exist
            if (!Directory.Exists(path))
            {
                DirectoryInfo _directoryInfo = new DirectoryInfo(path);

                foreach (FileInfo archivo in _directoryInfo.GetFiles())
                {
                    archivo.Delete();
                }
                foreach (DirectoryInfo folder in _directoryInfo.GetDirectories())
                {
                    folder.Delete(true);
                }

                Directory.Delete(path);
            }

            return RedirectToRoute(new { controller = "Anuncios", action = "Index" });
        }

        //Metodo que procesa subida de la imagen
        private string UploadFile(IFormFile file, int Id, bool editMode = false, string imgUrl=" ")
        {

            if (editMode)
            {
                if (file == null)
                {
                    return imgUrl = " ";
                }
            }

            //Get Directory path
            string basePath = $"/Img/Anuncios/{Id}";
            string path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot{basePath}");

            //Create folder if not exist
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            try
            {

                //Get File Path
                Guid guid = Guid.NewGuid();

                FileInfo fileInfo = new(file.FileName);


                string fileName = guid + fileInfo.Extension;

                //Ruta definitiva

                string fileNameWPath = Path.Combine(path, fileName);

                using (var stream = new FileStream(fileNameWPath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }

                if (editMode)
                {
                    string[] OldImgPart = imgUrl.Split("/");

                    string oldImagePath = OldImgPart[^1];

                    string completeImageOldPath = Path.Combine(path, oldImagePath);

                    if (System.IO.File.Exists(completeImageOldPath))
                    {
                        System.IO.File.Delete(completeImageOldPath);
                    }
                }

                return $"{basePath}/{fileName}";
            }
            catch (Exception )
            {

               
            }

            return $"{basePath}/{"Error"}";
        }

    }
}
