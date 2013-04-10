using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RSC.PreRetroVoting.DataAccess.FileSystem
{
  internal interface IRetroItemsFileProvider
  {
    IRetroItemsFile OpenRetroItemsFile();
  }
}
