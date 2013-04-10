using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RSC.PreRetroVoting.DataAccess.Xml;
using System.Xml.Linq;

namespace RSC.PreRetroVoting.DataAccess.RetroItemsAdders
{
  internal sealed class FileBasedRetroItemAdder : IRetroItemAdder
  {
    public FileBasedRetroItemAdder(IXmlFileProvider xmlFileProvider)
    {
      _xmlFileProvider = xmlFileProvider;
    }

    #region IRetroItemAdder Members

    public void AddRetroItem(string itemDescription)
    {
      using (var file = _xmlFileProvider.OpenXmlFile())
      {
        file.AddElement(new XElement(RetroItemXmlFile.RetroItemElementName, itemDescription));
        file.SaveFile();
      }
    }

    #endregion

    private readonly IXmlFileProvider _xmlFileProvider;
  }
}
