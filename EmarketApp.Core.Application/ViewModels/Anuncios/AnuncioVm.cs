using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmarketApp.Core.Application.ViewModels.Anuncios
{

    public class AnuncioVm
    {
        #region Anuncios
        public int Id { get; set; }
        [Required(ErrorMessage = "Debe colocar el nombre")]
        [DataType(DataType.Text)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Debe colocar la descripcion")]
        [DataType(DataType.Text)]
        public string Description { get; set; }
       

        [Required(ErrorMessage = "Ingrese el precio.")]
        [DataType(DataType.Currency)]
        public double Price { get; set; }

        public DateTime CreatedTime { get; set; }

        #endregion

        #region Category

        [Range(1, int.MaxValue, ErrorMessage = "Debe colocar una categoria del producto")]
        public int CategoryId { get; set; }

        [DataType(DataType.Currency)]
        public string CategoryName { get; set; }

        #endregion

        #region Img

        public string ImgFile1 { get; set; }
        public string ImgFile2 { get; set; }
        public string ImgFile3 { get; set; }
        public string ImgFile4 { get; set; } 

        #endregion








    }
}
