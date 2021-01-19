using System;
using System.Collections.Generic;
using System.Text;

namespace Teste.Direcional.Infra.Interfaces
{
    public interface IRepositorioBase<TClasse> where TClasse : class, new()
    {
    }
}