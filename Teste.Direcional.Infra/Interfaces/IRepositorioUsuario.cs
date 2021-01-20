using System;
using System.Collections.Generic;
using System.Text;
using Teste.Direcional.Dominio.Entidades;

namespace Teste.Direcional.Infra.Interfaces
{
    public interface IRepositorioUsuario : IRepositorioBase<Usuario>
    {
        int Salvar(Usuario registro);
    }
}