using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Teste.Direcional.WEB.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Informe seu Login!")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Informe sua Senha!")]
        public string Senha { get; set; }
    }
}
