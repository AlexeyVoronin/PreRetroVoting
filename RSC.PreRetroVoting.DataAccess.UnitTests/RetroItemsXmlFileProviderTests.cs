using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RSC.PreRetroVoting.DataAccess.FileSystem;

namespace RSC.PreRetroVoting.DataAccess.UnitTests
{
  [TestClass]
  public class RetroItemsXmlFileProviderTests
  {
    [TestMethod]
    public void GetRetroItemXmlFileTest()
    {
      var retroItemsXmlFileProvider = new RetroItemsXmlFileProvider();
      var file = retroItemsXmlFileProvider.OpenRetroItemsFile();

      Assert.IsNotNull(file);
      Assert.IsInstanceOfType(file, typeof(RetroItemsXmlFile));
    }

    [TestMethod]
    public void GettingRetroItemXmlFileNotCachedTest()
    {
      var retroItemsXmlFileProvider = new RetroItemsXmlFileProvider();
      var file1 = retroItemsXmlFileProvider.OpenRetroItemsFile();
      var file2 = retroItemsXmlFileProvider.OpenRetroItemsFile();

      Assert.IsFalse(object.ReferenceEquals(file1, file2));
    }
  }
}
