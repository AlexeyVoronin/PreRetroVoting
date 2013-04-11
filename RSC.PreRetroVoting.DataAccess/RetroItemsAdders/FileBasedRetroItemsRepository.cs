using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RSC.PreRetroVoting.DataAccess.Xml;
using System.Xml.Linq;

namespace RSC.PreRetroVoting.DataAccess.RetroItemsAdders
{
  internal sealed class FileBasedRetroItemsRepository : IRetroItemsRepository
  {
    public FileBasedRetroItemsRepository(IXmlFileProvider xmlFileProvider)
    {
      _xmlFileProvider = xmlFileProvider;
    }

    public void AddRetroItem(string itemDescription)
    {
      using (var file = _xmlFileProvider.OpenXmlFile())
      {
        file.AddElement(new XElement(RetroItemXmlFile.RetroItemElementName, itemDescription));
        file.SaveFile();
      }
    }

    public IEnumerable<string> GetRetroItems()
    {
      using (var file = _xmlFileProvider.OpenXmlFile())
      {
        return file.GetElements().Select(e => e.Value);
      }
    }

    private readonly IXmlFileProvider _xmlFileProvider;
  }
}
