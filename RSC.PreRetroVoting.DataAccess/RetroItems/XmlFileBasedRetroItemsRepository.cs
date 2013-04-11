using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RSC.PreRetroVoting.DataAccess.Xml;
using System.Xml.Linq;

namespace RSC.PreRetroVoting.DataAccess.RetroItemsAdders
{
  internal sealed class XmlFileBasedRetroItemsRepository : IRetroItemsRepository
  {
    public XmlFileBasedRetroItemsRepository(IXmlFileProvider xmlFileProvider)
    {
      _xmlFileProvider = xmlFileProvider;
    }

    public void AddRetroItem(RetroItem retroItem)
    {
      using (var file = _xmlFileProvider.OpenXmlFile())
      {
        file.AddElement(new XElement(RetroItemXmlFile.RetroItemElementName, retroItem.Description));
        file.SaveFile();
      }
    }

    public IEnumerable<RetroItem> GetRetroItems()
    {
      using (var file = _xmlFileProvider.OpenXmlFile())
      {
        return file.GetElements().Select(e => new RetroItem { Description = e.Value });
      }
    }

    private readonly IXmlFileProvider _xmlFileProvider;
  }
}
