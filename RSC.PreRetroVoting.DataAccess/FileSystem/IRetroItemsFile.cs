using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RSC.PreRetroVoting.DataAccess.FileSystem
{
  internal interface IRetroItemsFile : IDisposable
  {
    void AddRetroItem(string itemDescription);

    void SaveFile();

    IEnumerable<string> GetRetroItems();
  }
}
