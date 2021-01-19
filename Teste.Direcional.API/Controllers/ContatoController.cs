using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Teste.Direcional.API.Servicos;
using Teste.Direcional.Dominio.Entidades;

namespace Teste.Direcional.API.Controllers
{
    [Route("api/Contato")]
    [ApiController]
    public class ContatoController : ControllerBase
    {        
        [HttpPost]
        [Route("SalvarContato")]
        public IActionResult SalvarContato([FromBody]JObject objeto)
        {
            try
            {
                var contato = JsonConvert.DeserializeObject<Contato>(objeto["contato"].ToObject<string>());
                return Ok(new Contatos().SalvarContato(contato));
            }
            catch (Exception Ex)
            {
                return BadRequest(Ex.Message);
            }
        }
    }
}