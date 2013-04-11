using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RSC.PreRetroVoting.DataAccess.RetroItemsAdders;
using NMock;
using RSC.PreRetroVoting.DataAccess.Xml;
using System.Xml.Linq;

namespace RSC.PreRetroVoting.DataAccess.UnitTests
{
  [TestClass]
  public class XmlFileBasedRetroItemsRepositoryTests : TestWithMocks
  {
    [TestMethod]
    public void AddRetroItemTest()
    {
      var expectedRetroItem = new RetroItem { Description = "Test Retore Item 1" };

      var xmlFileProvider = MockFactory.CreateMock<IXmlFileProvider>();
      var xmlFile = MockFactory.CreateMock<IXmlFile>();
      var fileBasedRetroItemsRepository = new XmlFileBasedRetroItemsRepository(
        xmlFileProvider.MockObject);

      xmlFileProvider.Expects.One
        .MethodWith(o => o.OpenXmlFile())
        .WillReturn(xmlFile.MockObject);

      xmlFile.Expects.One
        .Method(o => o.AddElement(null))
        .With(Is.Match<XElement>(
          o => o.Name == RetroItemXmlFile.RetroItemElementName &&
               o.Value == expectedRetroItem.Description));
      xmlFile.Expects.One.MethodWith(
        o => o.SaveFile());
      xmlFile.Expects.One.MethodWith(
        o => o.Dispose());

      fileBasedRetroItemsRepository.AddRetroItem(expectedRetroItem);
    }

    [TestMethod]
    public void GetRetroItemsTest()
    {
      var expectedRetroItems = new[] {
        new RetroItem { Description = "Test Retore Item 1" }, 
        new RetroItem { Description = "Test Retore Item 2" }
      };
      var retroItemsElements = expectedRetroItems.Select(
        o => new XElement(RetroItemXmlFile.RetroItemElementName, o)).ToList();
      var xmlFileProvider = MockFactory.CreateMock<IXmlFileProvider>();
      var xmlFile = MockFactory.CreateMock<IXmlFile>();
      var fileBasedRetroItemsRepository = new XmlFileBasedRetroItemsRepository(
        xmlFileProvider.MockObject);

      xmlFileProvider.Expects.One
        .MethodWith(o => o.OpenXmlFile())
        .WillReturn(xmlFile.MockObject);

      xmlFile.Expects.One
        .MethodWith(o => o.GetElements())
        .WillReturn(retroItemsElements);

      xmlFile.Expects.One.MethodWith(
        o => o.Dispose());

      var actualRetroItems = fileBasedRetroItemsRepository.GetRetroItems().ToList();

      CollectionAssert.AreEquivalent(expectedRetroItems, actualRetroItems);
    }
  }
}
