using Ninject;
using RSC.PreRetroVoting.DataAccess.RetroItemsAdders;
using RSC.PreRetroVoting.DataAccess.Xml;
using RSC.PreRetroVoting.DataAccess.FileSystem;
using System.IO;

namespace RSC.PreRetroVoting.DataAccess
{
  public class NinjectDataAccessFacade : IDataAccessFacade
  {
    public NinjectDataAccessFacade()
    {
      RetroItemsStoragePath = Path.Combine(Path.GetTempPath(), RetroItemXmlFile.FileName);
      ConfigureKernel();
    }

    public string RetroItemsStoragePath { get; private set; }
    
    public IRetroItemsRepository RetroItemsRepository
    {
      get { return _kernel.Get<IRetroItemsRepository>(); }
    }

    private void ConfigureKernel()
    {
      _kernel.Bind<IRetroItemsRepository>().To<XmlFileBasedRetroItemsRepository>();
      _kernel.Bind<IXmlFileProvider>().To<TemplateXmlFileProviderDecorator>()
        .WhenInjectedInto<XmlFileBasedRetroItemsRepository>()
        .WithConstructorArgument("fileTemplate", RetroItemXmlFile.Template)
        .WithConstructorArgument("fileName", RetroItemsStoragePath);
      _kernel.Bind<IXmlFileProvider>().To<XDocumentFileProvider>()
        .WhenInjectedInto<TemplateXmlFileProviderDecorator>()
        .WithConstructorArgument("fileName", RetroItemsStoragePath);
      _kernel.Bind<IFileOperations>().To<FileOperations>();
    }
    
    private IKernel _kernel = new StandardKernel();
  }
}
