using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Ninject;
using RSC.PreRetroVoting.DataAccess.EF;
using RSC.PreRetroVoting.DataAccess.Model;
using RSC.PreRetroVoting.WebUi.Controllers;

namespace RSC.PreRetroVoting.WebUi.Infrastructure
{
    internal class NinjectDependencyResolver : IDependencyResolver
    {
        public NinjectDependencyResolver()
        {
            ConfigureKernel();
        }

        public object GetService(Type serviceType)
        {
            return serviceType == typeof(RetroItemsController) ? _kernel.Get(serviceType) : null;
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _kernel.GetAll(serviceType);
        }

        private void ConfigureKernel()
        {
            _kernel.Bind<IRetroItemsRepository>()
                   .ToMethod(c => new EntityFrameworkRetroItemsRepository())
                   .InSingletonScope();
        }

        private readonly IKernel _kernel = new StandardKernel();
    }
}