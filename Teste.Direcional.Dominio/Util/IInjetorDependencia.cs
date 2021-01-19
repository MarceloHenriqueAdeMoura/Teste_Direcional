using System;
using System.Collections.Generic;
using System.Text;

namespace Teste.Direcional.Dominio.Util
{
    public interface IInjetorDependencia
    {
        T Resolver<T>();

        T Resolver<T>(Type tipo);
    }
}
