using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
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
        private string fileName;

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
        public IActionResult Salvar(ContatoViewModel contatoViewModel, [FromServices] IHostingEnvironment hostingEnvironment, IFormFile file)
        {                        
            Contato contato = null;

            if (!string.IsNullOrEmpty(contatoViewModel.CPF))
            {
                if (Funcoes.IsCpf(contatoViewModel.CPF) && Funcoes.ValidarEmail(contatoViewModel.Email))
                {
                    fileName = null;

                    try
                    {
                        fileName = $"{hostingEnvironment.WebRootPath}\\files\\{file.FileName}";
                    }
                    catch (Exception e)
                    {
                        TempData["MensagemInvalido"] = " Favor inserir um arquivo!";
                        return View("Cadastrar");
                    }

                    using (FileStream fileStream = System.IO.File.Create(fileName))
                    {
                        file.CopyTo(fileStream);
                        fileStream.Flush();
                    }

                    contato = new Contato()
                    {                                         
                        Nome = contatoViewModel.Nome,
                        CPF = contatoViewModel.CPF,
                        Email = contatoViewModel.Email,
                        Anexo = fileName
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