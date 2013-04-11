using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RSC.PreRetroVoting.DataAccess.RetroItemsAdders;
using RSC.PreRetroVoting.DataAccess.Xml;
using RSC.PreRetroVoting.DataAccess.FileSystem;
using System.IO;

namespace RSC.PreRetroVoting.DataAccess
{
  public sealed class RetroItemsDataAccessFacade : IRetroItemsDataAccessFacade
  {
    public RetroItemsDataAccessFacade()
    {
      var rootDirectory = Path.GetTempPath();
      var retroItemsXmlFilePath = Path.Combine(rootDirectory, RetroItemXmlFile.FileName);
      var xmlFileProvider = new TemplateXmlFileProviderDecorator(
          new XDocumentFileProvider(retroItemsXmlFilePath),
          new FileOperations(),
          RetroItemXmlFile.Template,
          retroItemsXmlFilePath);
      Adder = new FileBasedRetroItemAdder(xmlFileProvider);
      Provider = new FileBasedRetroItemsProvider(xmlFileProvider);
    }

    #region IRetroItemsDataAccessFacade Members

    public IRetroItemAdder Adder { get; private set; }

    public IRetroItemsProvider Provider { get; private set; }

    #endregion
  }
}
