using EmarketApp.Core.Application.ViewModels.User;
using EmarketApp.Core.Domain.Entiities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmarketApp.Core.Application.Interfaces.Services
{
    public interface IUserService : IGenericService<SaveUserVm, UserVm>
    {
        Task<UserVm> Login(LoginVm vm);
    }

}
