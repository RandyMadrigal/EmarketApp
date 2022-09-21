using Emarket.Infrastructure.Persistence.Contexts;
using EmarketApp.Core.Application.Helpers;
using EmarketApp.Core.Application.Interfaces;
using EmarketApp.Core.Application.ViewModels.User;
using EmarketApp.Core.Domain.Entiities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Emarket.Infrastructure.Persistence.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly ApplicationContext _dbContext;

        public UserRepository(ApplicationContext dbContext) :base(dbContext)
        {
            _dbContext = dbContext;
        }

        public override async Task<User> AddAsync(User entity)
        {
            entity.Password = PasswordEncyption.ComputeSha256Hash(entity.Password);
                     
            return await base.AddAsync(entity);
        }

        public async Task<User> LoginAsyn(LoginVm vm)
        {
            string passwordEncrypty = PasswordEncyption.ComputeSha256Hash(vm.Password);

            User user = await _dbContext.Set<User>()
                .FirstOrDefaultAsync(user => user.UserName == vm.UserName && user.Password == passwordEncrypty);

            return user;
        }
    }
}

