using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Teste.Direcional.WEB.Models
{
    public class UsuarioViewModel
    {
        public int Id { get; set; }

        public string Login { get; set; }
   
        public string Senha { get; set; }    

    }
}
