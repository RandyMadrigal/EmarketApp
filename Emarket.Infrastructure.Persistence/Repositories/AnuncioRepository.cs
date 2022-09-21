using Emarket.Infrastructure.Persistence.Contexts;
using EmarketApp.Core.Application.Interfaces;
using EmarketApp.Core.Application.ViewModels.Anuncios;
using EmarketApp.Core.Domain.Entiities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Emarket.Infrastructure.Persistence.Repositories
{
    public class AnuncioRepository : GenericRepository<Anuncio>, IAnuncioRepository
    {
        private readonly ApplicationContext _dbContext;
       
        public AnuncioRepository(ApplicationContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        //Obtener por Id
        public  async Task<Anuncio> GetByIdAsyncInclude(int Id)
        {
            return await _dbContext.Set<Anuncio>()
                .Include("Category")                
                .FirstOrDefaultAsync(x => x.Id == Id);
        }
    }

}

