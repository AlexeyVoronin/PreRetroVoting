using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RSC.PreRetroVoting.DataAccess.FileSystem;

namespace RSC.PreRetroVoting.DataAccess.UnitTests
{
  [TestClass]
  public class RetroItemsXmlFileTests
  {
    [TestMethod]
    public void AddRetroItemTest()
    {
      const string ExpectedItemDescription = "Item Description 1";

      var retroItemsXmlFile = new RetroItemsXmlFile();

      retroItemsXmlFile.AddRetroItem(ExpectedItemDescription);
    }
  }
}
