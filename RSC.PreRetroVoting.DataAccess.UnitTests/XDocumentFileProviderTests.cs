using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RSC.PreRetroVoting.DataAccess.Xml;
using RSC.PreRetroVoting.DataAccess.FileSystem;
using RSC.PreRetroVoting.DataAccess.RetroItemsAdders;

namespace RSC.PreRetroVoting.DataAccess.UnitTests
{
  [TestClass]
  public class XDocumentFileProviderTests : TestWithMocks
  {
    [TestMethod]
    public void OpenXmlFileTest()
    {
      const string TestXmlFileName = "XDocumentFileProviderTests.OpenXmlFileTest.xml";

      var fileOperations = new FileOperations();
      fileOperations.WriteAllTextToFile(TestXmlFileName, RetroItemXmlFile.Template);

      var xDocumentFileProvider = new XDocumentFileProvider(TestXmlFileName);
      var actualResult = xDocumentFileProvider.OpenXmlFile();

      Assert.IsNotNull(actualResult);
      Assert.IsInstanceOfType(actualResult, typeof(XDocumentFile));

      var xDocumentFile = (XDocumentFile)actualResult;
      Assert.AreEqual(TestXmlFileName, xDocumentFile.FileName);
    }
  }
}
