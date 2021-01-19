using System;
using Teste.Direcional.Dominio.Util;
using Teste.Direcional.Infra.Interfaces;
using Teste.Direcional.Infra.Repositorios;
using Unity;

namespace Teste.Direcional.API.Comum
{
    public class InjetorDependencia : IInjetorDependencia
    {
        private readonly IUnityContainer _container;
        private static InjetorDependencia _injetorDependencia;

        private InjetorDependencia()
        {
            _container = new UnityContainer();
            MapearDependencias();
        }

        public static InjetorDependencia Instancia()
        {
            return _injetorDependencia ?? (_injetorDependencia = new InjetorDependencia());
        }

        public T Resolver<T>()
        {
            return _container.Resolve<T>();
        }

        public T Resolver<T>(Type type)
        {
            return (T)_container.Resolve(type);
        }

        private void MapearDependencias()
        {
            _container
                 .RegisterType<IRepositorioContato, RepositorioContato>();
        }
    }
}