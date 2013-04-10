using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RSC.PreRetroVoting.DataAccess.FileSystem
{
  internal interface IFileOperations
  {
    bool IsFileExists(string fileName);

    void WriteAllTextToFile(string fileName, string text);
  }
}
