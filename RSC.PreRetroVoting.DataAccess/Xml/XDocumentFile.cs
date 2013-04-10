using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace RSC.PreRetroVoting.DataAccess.Xml
{
  internal sealed class XDocumentFile : IXmlFile
  {
    public XDocumentFile(string fileName)
    {
      FileName = fileName;
      _document = XDocument.Load(fileName);
    }

    #region IXmlFile Members

    public string FileName { get; private set; }

    public void AddElement(XElement element)
    {
      _document.Root.Add(element);
    }

    public IEnumerable<XElement> GetElements()
    {
      return _document.Root.Elements();
    }

    public void SaveFile()
    {
      _document.Save(FileName);
    }

    #endregion

    #region IDisposable Members

    public void Dispose()
    {
    }

    #endregion

    private readonly XDocument _document;
  }
}
