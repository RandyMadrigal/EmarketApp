using EmarketApp.Core.Application.Interfaces;
using EmarketApp.Core.Application.Interfaces.Services;
using EmarketApp.Core.Application.ViewModels.User;
using EmarketApp.Core.Domain.Entiities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmarketApp.Core.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _UserRepository;

        public UserService(IUserRepository UserRepository)
        {
            _UserRepository = UserRepository;

        }

        //Agregar
        public async Task<SaveUserVm> Add(SaveUserVm vm)
        {
            User user = new();

                user.Name = vm.Name;
                user.Apellido = vm.Apellido;
                user.Email = vm.Email;
                user.Phone = vm.Telefono;
                user.UserName = vm.UserName;
                user.Password = vm.Password;


            user =  await _UserRepository.AddAsync(user);

            SaveUserVm userVm = new();
            userVm.Id = user.Id;
            userVm.Name = user.Name;
            userVm.Apellido = user.Apellido;
            userVm.Email = user.Email;
            userVm.Telefono = user.Phone;
            userVm.UserName = user.UserName;
            userVm.Password = user.Password;

            return userVm;
        }


        //Obtener todo
        public async Task<List<UserVm>> GetAllVm()
        {
            var UserList = await _UserRepository.GetAllAsyncWithIncludes(new List<string>{"Anuncios"});

            return UserList.Select(user => new UserVm
            {
                Name = user.Name,
                Apellido = user.Apellido,
                Email = user.Email,
                Telefono = user.Phone,
                UserName = user.UserName,
                Password = user.Password,

            }).ToList();
        }



        //Obtener POR ID
        public async Task<SaveUserVm> GetByIdSaveVm(int Id)
        {
            var user = await _UserRepository.GetByIdAsync(Id);

            SaveUserVm vm = new();

            vm.Id = user.Id;
            vm.Name = user.Name;
            vm.Apellido = user.Apellido;
            vm.Email = user.Email;
            vm.Telefono = user.Phone;
            vm.UserName = user.UserName;
            vm.Password = user.Password;

            return vm;
        }

        //Actualizar / editar
        public async Task Update(SaveUserVm vm)
        {
            User user = await _UserRepository.GetByIdAsync(vm.Id);

            user.Id = vm.Id;
            user.Name = vm.Name;
            user.Apellido = vm.Apellido;
            user.Email = vm.Email;
            user.Phone = vm.Telefono;
            user.UserName = vm.UserName;
            user.Password = vm.Password;

            await _UserRepository.UpdateAsync(user);
        }

        //Borrar
        public async Task Delete(int Id)
        {
            var user = await _UserRepository.GetByIdAsync(Id);
            await _UserRepository.DeleteAsync(user);

        }

        public async Task<UserVm> Login(LoginVm vm)
        {
            User user = await _UserRepository.LoginAsyn(vm);

            if(user == null)
            {
                return null;
            }

            UserVm userVm = new();

            userVm.Id = user.Id;
            userVm.Name = user.Name;
            userVm.Apellido = user.Apellido;
            userVm.Email = user.Email;
            userVm.Telefono = user.Phone;
            userVm.UserName = user.UserName;
            userVm.Password = user.Password;

            return userVm;
        }



    }
}
