using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using RSC.PreRetroVoting.DataAccess.Xml;

namespace RSC.PreRetroVoting.DataAccess.FileSystem
{
  internal sealed class RetroItemsXmlFile : IRetroItemsFile
  {
    public RetroItemsXmlFile(IXmlFileProvider xmlFileProvider)
    {
      _xmlFileProvider = xmlFileProvider;
    }

    #region IRetroItemsFile Members

    public void AddRetroItem(string itemDescription)
    {
      throw new NotImplementedException();
    }

    public void SaveFile()
    {
      throw new NotImplementedException();
    }

    public IEnumerable<string> GetRetroItems()
    {
      throw new NotImplementedException();
    }

    #endregion

    #region IDisposable Members

    public void Dispose()
    {
      throw new NotImplementedException();
    }

    #endregion

    private readonly IXmlFileProvider _xmlFileProvider;
  }
}
