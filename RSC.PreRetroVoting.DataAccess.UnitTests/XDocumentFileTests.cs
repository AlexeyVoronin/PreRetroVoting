using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RSC.PreRetroVoting.DataAccess.Xml;
using System.Xml.Linq;
using System.IO;
using RSC.PreRetroVoting.DataAccess.FileSystem;
using RSC.PreRetroVoting.DataAccess.RetroItemsAdders;

namespace RSC.PreRetroVoting.DataAccess.UnitTests
{
  [TestClass]
  public class XDocumentFileTests : TestWithMocks
  {
    [TestMethod]
    public void OpenFileTest()
    {
      const string TestFileName = "XDocumentFileTests.OpenFileTest";

      CreateTestXmlFile(TestFileName);

      using (var file = new XDocumentFile(TestFileName))
      {
        Assert.AreEqual(TestFileName, file.FileName);
      }
    }

    [TestMethod]
    public void AddXElementTest()
    {
      const string TestFileName = "XDocumentFileTests.AddXElementTest";

      CreateTestXmlFile(TestFileName);

      using (var file = new XDocumentFile(TestFileName))
      {
        var testElement = new XElement("TestElement", "Test Value");

        file.AddElement(testElement);
        file.SaveFile();
      }

      Assert.IsTrue(File.Exists(TestFileName));

      string testFileContent = File.ReadAllText(TestFileName);

      const string ExpectedFileContext = @"<?xml version=""1.0"" encoding=""utf-8""?>
<RetroItems>
  <TestElement>Test Value</TestElement>
</RetroItems>";

      Assert.AreEqual(ExpectedFileContext, testFileContent);
    }

    private void CreateTestXmlFile(string fileName)
    {
      var fileOperations = new FileOperations();
      fileOperations.WriteAllTextToFile(fileName, RetroItemXmlFile.Template);
    }
  }
}
