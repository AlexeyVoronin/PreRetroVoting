using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace RSC.PreRetroVoting.DataAccess.FileSystem
{
  internal sealed class FileOperations : IFileOperations
  {
    #region IFileOperations Members

    public bool IsFileExists(string fileName)
    {
      return File.Exists(fileName);
    }

    public void WriteAllTextToFile(string fileName, string text)
    {
      File.WriteAllText(fileName, text);
    }

    #endregion
  }
}
