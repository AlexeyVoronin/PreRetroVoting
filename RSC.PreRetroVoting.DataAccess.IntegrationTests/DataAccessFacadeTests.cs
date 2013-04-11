using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace RSC.PreRetroVoting.DataAccess.IntegrationTests
{
  [TestClass]
  public class DataAccessFacadeTests
  {
    [TestMethod]
    public void AddingRetroItemTest()
    {
      IDataAccessFacade retroItemsDataAccessFacade = new DataAccessFacade();
      
      File.Delete(retroItemsDataAccessFacade.RetroItemsStoragePath);

      IRetroItemsRepository retroItemsRepository = retroItemsDataAccessFacade.RetroItemsRepository;

      const string TestMessage = "testItem";

      retroItemsRepository.AddRetroItem(TestMessage);

      var result = retroItemsRepository.GetRetroItems();

      CollectionAssert.AreEquivalent(new[] { TestMessage }, result.ToList());
    }
  }
}
