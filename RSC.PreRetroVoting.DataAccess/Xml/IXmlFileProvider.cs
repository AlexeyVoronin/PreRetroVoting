using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RSC.PreRetroVoting.DataAccess.Xml
{
  internal interface IXmlFileProvider
  {
    IXmlFile OpenXmlFile();
  }
}
