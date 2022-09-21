using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmarketApp.Core.Application.ViewModels.Categories
{
    public class CategoryVm
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Debe colocar un Nombre")]
        [DataType(DataType.Text)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Debe colocar una Descripcion")]
        [DataType(DataType.Text)]
        public string Description { get; set; }
        public int AnuncioQuantity { get; set; }
        public int UserQuantity { get; set; }
    }
}
