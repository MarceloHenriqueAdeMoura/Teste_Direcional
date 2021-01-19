using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Teste.Direcional.Dominio.Entidades;
using Teste.Direcional.Infra.Interfaces;
using Teste.Direcional.Infra.Repositorios;

namespace Teste.Direcional.Infra.Repositorios
{
    public class RepositorioContato : RepositorioBase<Contato>, IRepositorioContato
    {
        public int Salvar(Contato registro)
        {
            throw new NotImplementedException();
        }
    }
}
