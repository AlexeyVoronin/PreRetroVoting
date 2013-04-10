using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RSC.PreRetroVoting.DataAccess.Xml;
using RSC.PreRetroVoting.DataAccess.FileSystem;

namespace RSC.PreRetroVoting.DataAccess.UnitTests
{
  [TestClass]
  public class TemplateXmlFileProviderDecoratorTests : TestWithMocks
  {
    [TestMethod]
    public void OpenNotExistsXmlFile()
    {
      var baseFileProvider = MockFactory.CreateMock<IXmlFileProvider>();
      var fileOperations = MockFactory.CreateMock<IFileOperations>();
      var fileName = "TemplateXmlFileProviderDecoratorTests.OpenNotExistsXmlFile.xml";
      var fileTemplate = "FileTemplate";

      var decorator = new TemplateXmlFileProviderDecorator(
        baseFileProvider.MockObject,
        fileOperations.MockObject,
        fileTemplate,
        fileName);

      var expectedResult = MockFactory.CreateMock<IXmlFile>();

      fileOperations.Expects.One.MethodWith(o => o.IsFileExists(fileName)).WillReturn(false);
      fileOperations.Expects.One.MethodWith(o => o.WriteAllTextToFile(fileName, fileTemplate));

      baseFileProvider.Expects.One.MethodWith(o => o.OpenXmlFile()).WillReturn(expectedResult.MockObject);

      var actualResult = decorator.OpenXmlFile();

      Assert.AreEqual(expectedResult.MockObject, actualResult);
    }

    [TestMethod]
    public void OpenExistsXmlFile()
    {
      var baseFileProvider = MockFactory.CreateMock<IXmlFileProvider>();
      var fileOperations = MockFactory.CreateMock<IFileOperations>();
      var fileName = "TemplateXmlFileProviderDecoratorTests.OpenExistsXmlFile.xml";
      var fileTemplate = "FileTemplate";

      var decorator = new TemplateXmlFileProviderDecorator(
        baseFileProvider.MockObject,
        fileOperations.MockObject,
        fileTemplate,
        fileName);

      var expectedResult = MockFactory.CreateMock<IXmlFile>();

      fileOperations.Expects.One.MethodWith(o => o.IsFileExists(fileName)).WillReturn(true);

      baseFileProvider.Expects.One.MethodWith(o => o.OpenXmlFile()).WillReturn(expectedResult.MockObject);

      var actualResult = decorator.OpenXmlFile();

      Assert.AreEqual(expectedResult.MockObject, actualResult);
    }
  }
}
