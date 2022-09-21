
using EmarketApp.Core.Application.Helpers;
using EmarketApp.Core.Application.Interfaces;
using EmarketApp.Core.Application.Interfaces.Services;
using EmarketApp.Core.Application.ViewModels.Categories;
using EmarketApp.Core.Application.ViewModels.User;
using EmarketApp.Core.Domain.Entiities;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmarketApp.Core.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _CategoryRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserVm _userVm;

        public CategoryService(ICategoryRepository categoryRepository, IHttpContextAccessor httpContextAccessor)
        {
            _CategoryRepository = categoryRepository;
            _httpContextAccessor = httpContextAccessor;
            _userVm = _httpContextAccessor.HttpContext.Session.Get<UserVm>("user");

        }

        public async Task<List<CategoryVm>> GetAllVm()
        {
            var CategoryList = await _CategoryRepository.GetAllAsyncWithIncludes(new List<string> { "Anuncios" });

            return CategoryList.Select(category => new CategoryVm{

                Id = category.Id,
                Name = category.Name,
                Description = category.Description,
                AnuncioQuantity = category.Anuncios.Select(anuncios => anuncios.UserId).Count(),
                UserQuantity = category.Anuncios.Select(anuncios => anuncios.UserId).Distinct().Count()

            }).ToList();
        }

        public async Task<SaveCategoryVm> Add(SaveCategoryVm vm)
        {
            Category category = new();

            category.Name = vm.Name;
            category.Description = vm.Description;

            category = await _CategoryRepository.AddAsync(category);

            SaveCategoryVm categoryVm = new();

            categoryVm.Id = category.Id;
            categoryVm.Name = category.Name;
            categoryVm.Description = category.Description;

            return categoryVm;
        }

        public async Task<SaveCategoryVm> GetByIdSaveVm(int Id)
        {
            var category = await _CategoryRepository.GetByIdAsync(Id);

            SaveCategoryVm vm = new();

            vm.Id = category.Id;
            vm.Name = category.Name;
            vm.Description = category.Description;

            return vm;
        }

        public async Task Update(SaveCategoryVm vm)
        {
            Category category = await _CategoryRepository.GetByIdAsync(vm.Id);

            category.Id = vm.Id;
            category.Name = vm.Name;
            category.Description = vm.Description;

            await _CategoryRepository.UpdateAsync(category);
        }

        public async Task Delete(int Id)
        {
            var anuncio = await _CategoryRepository.GetByIdAsync(Id);
            await _CategoryRepository.DeleteAsync(anuncio);

        }











    }
}
