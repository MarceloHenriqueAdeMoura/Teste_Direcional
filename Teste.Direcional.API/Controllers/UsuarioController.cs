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
    [Route("api/Usuario")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        [HttpPost]
        [Route("ObterUsuarioPorLogin")]
        public IActionResult ObterUsuarioPorLogin([FromForm] string cpf)
        {
            try
            {
                return Ok(new Usuarios().ObterUsuarioPorLogin(cpf));
            }
            catch (Exception Ex)
            {
                return BadRequest(Ex.Message);
            }
        }

        [HttpPost]
        [Route("SalvarUsuario")]
        public IActionResult SalvarUsuario([FromBody]JObject objeto)
        {
            try
            {
                var usuario = JsonConvert.DeserializeObject<Usuario>(objeto["usuario"].ToObject<string>());
                return Ok(new Usuarios().SalvarUsuario(usuario));
            }
            catch (Exception Ex)
            {
                return BadRequest(Ex.Message);
            }
        }
    }
}