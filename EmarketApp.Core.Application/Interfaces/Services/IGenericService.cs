using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmarketApp.Core.Application.Interfaces.Services
{
    public interface IGenericService<SaveViewModel,ViewModel>
        where SaveViewModel : class
        where ViewModel : class
    {
        Task<List<ViewModel>> GetAllVm();
        Task<SaveViewModel> Add(SaveViewModel vm);
        Task<SaveViewModel> GetByIdSaveVm(int Id);
        Task Update(SaveViewModel vm);
        Task Delete(int Id);
    }
}
