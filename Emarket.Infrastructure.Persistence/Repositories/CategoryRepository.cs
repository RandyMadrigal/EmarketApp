using Emarket.Infrastructure.Persistence.Contexts;
using EmarketApp.Core.Application.Interfaces;
using EmarketApp.Core.Domain.Entiities;


namespace Emarket.Infrastructure.Persistence.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        private readonly ApplicationContext _dbContext;

        public CategoryRepository(ApplicationContext dbContext) :base(dbContext)
        {
            _dbContext = dbContext;
        }

    }

}

