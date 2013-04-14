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
        var retroItemElement = new XElement(RetroItemXmlFile.RetroItemElementName, retroItem.Description);
        retroItemElement.SetAttributeValue(
          XName.Get(RetroItemXmlFile.RetroItemIdAttributeName),
          Guid.NewGuid());

        file.AddElement(retroItemElement);

        file.SaveFile();
      }
    }

    public IEnumerable<RetroItem> GetRetroItems()
    {
      using (var file = _xmlFileProvider.OpenXmlFile())
      {
        return file.GetElements().Select(e => 
          new RetroItem
          {
            Id = GetGuidOrEmpty(e, RetroItemXmlFile.RetroItemIdAttributeName),
            Description = e.Value 
          });
      }
    }

    private Guid GetGuidOrEmpty(XElement element, string attributeName)
    {
      var attribute = element.Attribute(attributeName);
      
      return attribute != null ? Guid.Parse(attribute.Value) : Guid.Empty;
    }

    private readonly IXmlFileProvider _xmlFileProvider;
  }
}
