using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Linq;
using Teste.Direcional.Dominio.Entidades;
using Teste.Direcional.Dominio.Properties;
using Teste.Direcional.WEB.Models;

namespace Teste.Direcional.WEB.Controllers
{
    public class LoginController : Controller
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            ModelState.Clear();
            return View("Cadastrar");
        }

        [HttpPost]
        public IActionResult ValidarLogin(LoginViewModel loginViewModel)
        {
            if (!string.IsNullOrEmpty(loginViewModel.Login))
            {
                var usuario = new UsuarioViewModel();
                var client = new RestClient(Settings.Default.UrlBase);
                var requestUsuario = new RestRequest(Settings.Default.ObterUsuarioPorLogin, Method.GET);
                requestUsuario.AddParameter("cpf", loginViewModel.Login);
                var responseUsuario = client.Execute(requestUsuario);
                var contentUsuario = responseUsuario.Content;
                var retornoUsuario = JsonConvert.DeserializeObject<Usuario>(contentUsuario);

                if (retornoUsuario == null)
                {
                    TempData["MensagemInvalido"] = " Usuário não cadastrado no sistema!";
                    return RedirectToAction("Index");
                }

                if (loginViewModel.Senha != retornoUsuario.Senha)
                {
                    TempData["MensagemInvalido"] = " Dados de login inválido!";
                    return RedirectToAction("Index");
                }

                usuario = new UsuarioViewModel()
                {
                    Id = retornoUsuario.Id,
                    Login = retornoUsuario.Login,
                    Senha = retornoUsuario.Senha
                };

                if (usuario != null)
                {
                    HttpContext.Session.SetString("IdUsuario", usuario.Id.ToString());
                    HttpContext.Session.SetString("LoginUsuario", usuario.Login);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    TempData["MensagemInvalido"] = " Usuario inativo!";
                    return RedirectToAction("Index");
                }
            }

            TempData["MensagemInvalido"] = " Dados de login inválido!";
            return RedirectToAction("Index");
        }                
    }
}