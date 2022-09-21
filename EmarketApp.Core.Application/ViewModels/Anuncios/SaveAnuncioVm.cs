using EmarketApp.Core.Application.ViewModels.Categories;
using EmarketApp.Core.Application.ViewModels.User;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmarketApp.Core.Application.ViewModels.Anuncios
{
    public class SaveAnuncioVm
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
        [Range(1, int.MaxValue, ErrorMessage = "El precio debe ser mayor a RD$ 0.00")]
        [DataType(DataType.Currency)]
        public double Price { get; set; }
        public DateTime Created { get; set; }
        public string Autor { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        #endregion

        #region Category

        public List<CategoryVm> CategoriesList { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Debe colocar la categoria")]
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        #endregion


        #region Img
        public string ImgFile1 { get; set; }
        public string ImgFile2 { get; set; }
        public string ImgFile3 { get; set; }
        public string ImgFile4 { get; set; }


        //Subida de archivos -IFormFile
        [DataType(DataType.Upload)]
        public IFormFile File1 { get; set; }

        [DataType(DataType.Upload)]
        public IFormFile File2 { get; set; }

        [DataType(DataType.Upload)]
        public IFormFile File3 { get; set; }

        [DataType(DataType.Upload)]
        public IFormFile File4 { get; set; }

        #endregion












    }

}
