using EmarketApp.Core.Application.Helpers;
using EmarketApp.Core.Application.Interfaces;
using EmarketApp.Core.Application.Interfaces.Services;
using EmarketApp.Core.Application.ViewModels.Anuncios;
using EmarketApp.Core.Application.ViewModels.User;
using EmarketApp.Core.Domain.Entiities;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmarketApp.Core.Application.Services
{
    public class AnuncioService : IAnuncioService
    {
        private readonly IAnuncioRepository _AnuncioRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserVm _userVm;
        


        public AnuncioService(IAnuncioRepository AnuncioRepository, IHttpContextAccessor httpContextAccessor)
        {
            _AnuncioRepository = AnuncioRepository;
            _httpContextAccessor = httpContextAccessor;
            _userVm = _httpContextAccessor.HttpContext.Session.Get<UserVm>("user");
         

        }

        //Actualizar / editar
        public async Task Update(SaveAnuncioVm vm)
        {
            Anuncio anuncio = await _AnuncioRepository.GetByIdAsync(vm.Id);

            anuncio.Id = vm.Id;
            anuncio.Name = vm.Name;
            anuncio.Description = vm.Description;           
            anuncio.Price = vm.Price;
            anuncio.Created = vm.Created;
            anuncio.CategoryId = vm.CategoryId;
            anuncio.UserId = _userVm.Id;
            anuncio.ImgFile1 = vm.ImgFile1;
            anuncio.ImgFile2 = vm.ImgFile2;
            anuncio.ImgFile3 = vm.ImgFile3;
            anuncio.ImgFile4 = vm.ImgFile4;

            await _AnuncioRepository.UpdateAsync(anuncio);
        }

        //Agregar
        public async Task<SaveAnuncioVm> Add(SaveAnuncioVm vm)
        {
          
            Anuncio anuncio = new();

            anuncio.Name = vm.Name;
            anuncio.Description = vm.Description;            
            anuncio.Price = vm.Price;
            anuncio.Created = vm.Created;
            anuncio.CategoryId = vm.CategoryId;
            anuncio.UserId = _userVm.Id;
            anuncio.ImgFile1 = vm.ImgFile1;
            anuncio.ImgFile2 = vm.ImgFile2;
            anuncio.ImgFile3 = vm.ImgFile3;
            anuncio.ImgFile4 = vm.ImgFile4;


            anuncio = await _AnuncioRepository.AddAsync(anuncio);

            SaveAnuncioVm anuncioVm = new();

            anuncioVm.Id = anuncio.Id;
            anuncioVm.Name = anuncio.Name;
            anuncioVm.Description = anuncio.Description;            
            anuncioVm.Price = anuncio.Price;
            anuncioVm.Created = anuncio.Created;
            anuncioVm.CategoryId = anuncio.CategoryId;
            anuncioVm.ImgFile1 = anuncio.ImgFile1;
            anuncioVm.ImgFile2 = anuncio.ImgFile2;
            anuncioVm.ImgFile3 = anuncio.ImgFile3;
            anuncioVm.ImgFile4 = anuncio.ImgFile4;

            return anuncioVm;
        }

        //Borrar
        public async Task Delete(int Id)
        {
            var anuncio = await _AnuncioRepository.GetByIdAsync(Id);
            await _AnuncioRepository.DeleteAsync(anuncio);
        }

        //Obtener POR ID
        
        public async Task<SaveAnuncioVm> GetByIdSaveVm(int Id)
        {
            var anuncio = await _AnuncioRepository.GetByIdAsync(Id);

            SaveAnuncioVm vm = new();
            vm.Id = anuncio.Id;
            vm.Name = anuncio.Name;
            vm.Description = anuncio.Description;            
            vm.Price = anuncio.Price;
            vm.CategoryId = anuncio.CategoryId;
            vm.ImgFile1 = anuncio.ImgFile1;
            vm.ImgFile2 = anuncio.ImgFile2;
            vm.ImgFile3 = anuncio.ImgFile3;
            vm.ImgFile4 = anuncio.ImgFile4;

            return vm;
        }
        
        public async Task<SaveAnuncioVm> GetByIdSaveVmInclude(int Id)
        {
            var anuncio = await _AnuncioRepository.GetByIdAsyncInclude(Id);

            SaveAnuncioVm vm = new();

            vm.Id = anuncio.Id;
            vm.Name = anuncio.Name;
            vm.Description = anuncio.Description;           
            vm.Price = anuncio.Price;
            vm.Created = anuncio.Created;
            vm.Autor = anuncio.Autor;
            vm.Email = anuncio.Email;
            vm.Phone = anuncio.Phone;
            vm.CategoryName = anuncio.Category.Name;
            vm.ImgFile1 = anuncio.ImgFile1;
            vm.ImgFile2 = anuncio.ImgFile2;
            vm.ImgFile3 = anuncio.ImgFile3;
            vm.ImgFile4 = anuncio.ImgFile4;

            return vm;
        }

        //Obtener todas mis publicaciones
        public async Task<List<AnuncioVm>> GetAllVm()
        {
            var AnuncioList = await _AnuncioRepository.GetAllAsyncWithIncludes(new List<string>{"Category"});

            return AnuncioList.Where(anuncio => anuncio.UserId == _userVm.Id).Select(anuncio => new AnuncioVm{

                Id = anuncio.Id,
                Name = anuncio.Name,
                Description = anuncio.Description,                
                Price = anuncio.Price,

                CategoryId = anuncio.CategoryId,
                CategoryName =  anuncio.Category.Name,

                ImgFile1 = anuncio.ImgFile1,
                ImgFile2 = anuncio.ImgFile2,
                ImgFile3 = anuncio.ImgFile3,
                ImgFile4 = anuncio.ImgFile4,

        }).ToList();
        }

        //Obtener todas las publicaciones de los usuarios -- con filtro
        public async Task<List<AnuncioVm>> GetAllVmWithFilter(FilterAnuncioVm filters)
        {
            var AnuncioList = await _AnuncioRepository.GetAllAsyncWithIncludes(new List<string> { "Category"});

            var listVm = AnuncioList.Where(anuncio => anuncio.UserId != _userVm.Id).Select(anuncio => new AnuncioVm
            {
                Id = anuncio.Id,
                Name = anuncio.Name,
                Description = anuncio.Description,                
                Price = anuncio.Price,
                CreatedTime = anuncio.Created,
                CategoryId = anuncio.Category.Id,
                CategoryName = anuncio.Category.Name,
                ImgFile1 = anuncio.ImgFile1,
                ImgFile2 = anuncio.ImgFile2,
                ImgFile3 = anuncio.ImgFile3,
                ImgFile4 = anuncio.ImgFile4,

            }).ToList();

            var prueba = filters;

            if (filters.CategoryId != null)
            {
                listVm = listVm.Where(anuncio => anuncio.CategoryId == filters.CategoryId.Value).ToList();
            }

            if (filters.CategoryName != null) //LIKE
            {
                listVm = listVm.Where(anuncio => anuncio.Name.Contains(filters.CategoryName)).ToList();
            }

            return listVm;
        }
         
       }
    }

