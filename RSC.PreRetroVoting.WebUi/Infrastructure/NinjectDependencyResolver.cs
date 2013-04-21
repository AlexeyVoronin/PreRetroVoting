using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Ninject;
using RSC.PreRetroVoting.DataAccess;
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
      if (serviceType == typeof(RetroItemsController))
        return _kernel.Get(serviceType);
      else
        return null;
    }

    public IEnumerable<object> GetServices(Type serviceType)
    {
      return _kernel.GetAll(serviceType);
    }

    private void ConfigureKernel()
    {
      _kernel.Bind<IRetroItemsRepository>().ToMethod(c => new NinjectDataAccessFacade().RetroItemsRepository);
    }

    private IKernel _kernel = new StandardKernel();
  }
}