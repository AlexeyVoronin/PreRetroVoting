using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RSC.PreRetroVoting.DataAccess.Xml;
using System.Xml.Linq;

namespace RSC.PreRetroVoting.DataAccess.RetroItemsAdders
{
  internal sealed class FileBasedRetroItemsProvider : IRetroItemsProvider
  {
    public FileBasedRetroItemsProvider(IXmlFileProvider xmlFileProvider)
    {
      _xmlFileProvider = xmlFileProvider;
    }

    #region IRetroItemsProvider Members

    public IEnumerable<string> GetRetroItems()
    {
      using (var file = _xmlFileProvider.OpenXmlFile())
      {
        return file.GetElements().Select(e => e.Value);
      }
    }

    #endregion

    private readonly IXmlFileProvider _xmlFileProvider;
  }
}
