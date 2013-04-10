using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RSC.PreRetroVoting.DataAccess.RetroItemsAdders;
using RSC.PreRetroVoting.DataAccess.Xml;
using RSC.PreRetroVoting.DataAccess.FileSystem;

namespace RSC.PreRetroVoting.DataAccess
{
  public sealed class RetroItemsDataAccessFacade : IRetroItemsDataAccessFacade
  {
    public RetroItemsDataAccessFacade()
    {      
      var xmlFileProvider = new TemplateXmlFileProviderDecorator(
          new XDocumentFileProvider(RetroItemXmlFile.FileName),
          new FileOperations(),
          RetroItemXmlFile.Template,
          RetroItemXmlFile.FileName);
      Adder = new FileBasedRetroItemAdder(xmlFileProvider);
      Provider = new FileBasedRetroItemsProvider(xmlFileProvider);
    }

    #region IRetroItemsDataAccessFacade Members

    public IRetroItemAdder Adder { get; private set; }

    public IRetroItemsProvider Provider { get; private set; }

    #endregion
  }
}
