using EmarketApp.Core.Application.Interfaces.Repositoires;
using EmarketApp.Core.Application.ViewModels.User;
using EmarketApp.Core.Domain.Entiities;
using System.Threading.Tasks;

namespace EmarketApp.Core.Application.Interfaces
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User> LoginAsyn(LoginVm vm);
    }
}
