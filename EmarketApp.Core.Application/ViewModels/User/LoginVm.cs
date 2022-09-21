using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmarketApp.Core.Application.ViewModels.User
{
    public class LoginVm
    {
        [Required(ErrorMessage = "Debe colocar Nombre de Usuario")]
        [DataType(DataType.Text)]      
        public string UserName { get; set; }


        [Required(ErrorMessage = "Debe colocar una Contraseña")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
