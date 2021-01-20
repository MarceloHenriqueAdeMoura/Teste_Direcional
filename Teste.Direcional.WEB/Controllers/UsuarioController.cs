using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using RestSharp;
using Teste.Direcional.Dominio.Entidades;
using Teste.Direcional.Dominio.Properties;
using Teste.Direcional.Infra.Recursos;
using Teste.Direcional.WEB.Models;

namespace Teste.Direcional.WEB.Controllers
{
    public class UsuarioController : Controller
    {
        private static Usuario _usuario;

        public IActionResult Index()
        {
            return RedirectToAction("Index", "Login");
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            ModelState.Clear();
            return RedirectToAction("Cadastrar", "Login");
        }

        [HttpPost]
        public IActionResult Salvar(UsuarioViewModel usuarioViewModel)
        {
            Usuario usuario = null;

            if (!string.IsNullOrEmpty(usuarioViewModel.Login) && !string.IsNullOrEmpty(usuarioViewModel.Senha))
            {
                if (Funcoes.ValidarSenha(usuarioViewModel.Senha))
                {
                    usuario = new Usuario()
                    {
                        //Id = usuarioViewModel.Id,
                        Login = usuarioViewModel.Login,
                        Senha = usuarioViewModel.Senha
                    };

                    var client = new RestClient(Settings.Default.UrlBase);
                    var request = new RestRequest(Settings.Default.SalvarUsuario);
                    request.AddJsonBody(new { usuario = JsonConvert.SerializeObject(usuario) });
                    request.RequestFormat = DataFormat.Json;
                    var response = client.Post(request);
                    var content = response.Content;
                    var retornoUsuario = JsonConvert.DeserializeObject<int>(content);

                    TempData["MensagemValido"] = " Usuário cadastrado no sistema!";
                    ModelState.Clear();
                    return RedirectToAction("Index", "Login");
                }
                else
                {
                    TempData["MensagemInvalido"] = " Senha inválida!";
                    return RedirectToAction("Index", "Login");
                }                
            }
            TempData["MensagemInvalido"] = " Erro ao cadastrar usuário no sistema!";
            return RedirectToAction("Index", "Login");
        }
    }
}