
using EmarketApp.Core.Application.Interfaces.Repositoires;
using EmarketApp.Core.Application.ViewModels.Anuncios;
using EmarketApp.Core.Domain.Entiities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmarketApp.Core.Application.Interfaces
{
    public interface IAnuncioRepository : IGenericRepository<Anuncio>
    {
        Task<Anuncio> GetByIdAsyncInclude(int id);




    }
      
}
