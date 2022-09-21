using EmarketApp.Core.Application.ViewModels.Anuncios;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmarketApp.Core.Application.Interfaces.Services
{
    public interface IAnuncioService : IGenericService<SaveAnuncioVm, AnuncioVm>
    {
        Task<List<AnuncioVm>> GetAllVmWithFilter(FilterAnuncioVm filters);

        Task<SaveAnuncioVm> GetByIdSaveVmInclude(int Id);


    }

}
