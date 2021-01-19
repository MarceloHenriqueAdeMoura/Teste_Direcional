using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Teste.Direcional.Dominio.Entidades;
using Teste.Direcional.Dominio.Util;
using Teste.Direcional.Infra.Repositorios;

namespace Teste.Direcional.API.Servicos
{
    public class Contatos
    {       
        public int SalvarContato(Contato contato)
        {
            return IoC.Resolver<RepositorioContato>().Salvar(contato);
        }
    }
}
