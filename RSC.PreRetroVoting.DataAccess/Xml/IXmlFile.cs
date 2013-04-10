using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace RSC.PreRetroVoting.DataAccess.Xml
{
  internal interface IXmlFile : IDisposable
  {
    string FileName { get; }

    void AddElement(XElement element);

    IEnumerable<XElement> GetElements();

    void SaveFile();
  }
}
