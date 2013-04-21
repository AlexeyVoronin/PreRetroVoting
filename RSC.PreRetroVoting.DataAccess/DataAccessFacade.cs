using RSC.PreRetroVoting.DataAccess.RetroItemsAdders;
using RSC.PreRetroVoting.DataAccess.Xml;
using RSC.PreRetroVoting.DataAccess.FileSystem;
using System.IO;

namespace RSC.PreRetroVoting.DataAccess
{
  public sealed class DataAccessFacade : IDataAccessFacade
  {
    public DataAccessFacade()
    {
      RetroItemsStoragePath = Path.Combine(Path.GetTempPath(), RetroItemXmlFile.FileName);
      RetroItemsRepository = new XmlFileBasedRetroItemsRepository(
        new TemplateXmlFileProviderDecorator(
          new XDocumentFileProvider(RetroItemsStoragePath),
          new FileOperations(),
          RetroItemXmlFile.Template,
          RetroItemsStoragePath));
    }

    #region IRetroItemsDataAccessFacade Members

    public string RetroItemsStoragePath { get; private set; }

    public IRetroItemsRepository RetroItemsRepository { get; private set; }

    #endregion
  }
}
