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
    public class ContatoController : Controller
    {
        private static Contato _contato;

        [HttpGet]
        public IActionResult Index(int? page)
        {
            return View("Index");
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            ModelState.Clear();
            return View("Cadastrar");
        }

        [HttpPost]
        public IActionResult Salvar(ContatoViewModel contatoViewModel)
        {
            Contato contato = null;

            if (!string.IsNullOrEmpty(contatoViewModel.CPF))
            {
                if (Funcoes.IsCpf(contatoViewModel.CPF) && Funcoes.ValidarEmail(contatoViewModel.Email))
                {
                    contato = new Contato()
                    {
                        //Id = contatoViewModel.Id,                    
                        Nome = contatoViewModel.Nome,
                        CPF = contatoViewModel.CPF,
                        Email = contatoViewModel.Email,
                        Anexo = contatoViewModel.Anexo
                    };

                    var client = new RestClient(Settings.Default.UrlBase);
                    var request = new RestRequest(Settings.Default.SalvarContato);
                    request.AddJsonBody(new { contato = JsonConvert.SerializeObject(contato) });
                    request.RequestFormat = DataFormat.Json;
                    var response = client.Post(request);
                    var content = response.Content;
                    var retornoContato = JsonConvert.DeserializeObject<int>(content);

                    TempData["MensagemCadastrarSalvo"] = " Contato cadastrado no sistema!";
                    ModelState.Clear();
                    return View("Cadastrar");
                }
            }

            TempData["MensagemCadastrarInvalido"] = " Erro ao cadastrar contato no sistema!";
            return View("Cadastrar");
        }
    }
}