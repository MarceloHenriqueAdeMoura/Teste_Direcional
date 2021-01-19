using System;

namespace Teste.Direcional.Dominio.Util
{
    public class IoC
    {
        private static IInjetorDependencia _injetor;

        public static void Inicializar(IInjetorDependencia injetor)
        {
            _injetor = injetor;
        }

        public static T Resolver<T>(Type type)
        {
            return _injetor.Resolver<T>(type);
        }

        public static T Resolver<T>()
        {
            return _injetor.Resolver<T>();
        }
    }
}
