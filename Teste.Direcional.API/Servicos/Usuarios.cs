using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Teste.Direcional.Dominio.Entidades;
using Teste.Direcional.Dominio.Util;
using Teste.Direcional.Infra.Repositorios;

namespace Teste.Direcional.API.Servicos
{
    public class Usuarios
    {
        public Usuario ObterUsuarioPorLogin(string cpf)
        {
            return IoC.Resolver<RepositorioUsuario>().ObterPorLogin(cpf);
        }

        public int SalvarUsuario(Usuario usuario)
        {
            return IoC.Resolver<RepositorioUsuario>().Salvar(usuario);
        }
    }
}
