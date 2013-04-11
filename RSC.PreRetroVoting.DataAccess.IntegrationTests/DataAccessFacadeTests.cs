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

      var testRetroItem = new RetroItem { Description = "testItem" };

      retroItemsRepository.AddRetroItem(testRetroItem);

      var result = retroItemsRepository.GetRetroItems();

      CollectionAssert.AreEquivalent(new[] { testRetroItem }, result.ToList());
    }
  }
}
