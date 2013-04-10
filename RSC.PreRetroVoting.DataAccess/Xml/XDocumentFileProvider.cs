using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RSC.PreRetroVoting.DataAccess.Xml
{
  internal sealed class XDocumentFileProvider : IXmlFileProvider
  {
    public XDocumentFileProvider(string fileName)
    {
      _fileName = fileName;
    }

    #region IXmlFileProvider Members

    public IXmlFile OpenXmlFile()
    {
      return new XDocumentFile(_fileName);
    }

    #endregion

    private readonly string _fileName;
  }
}
