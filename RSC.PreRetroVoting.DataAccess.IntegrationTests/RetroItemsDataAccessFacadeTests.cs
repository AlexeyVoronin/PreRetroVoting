using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RSC.PreRetroVoting.DataAccess.IntegrationTests
{
  [TestClass]
  public class RetroItemsDataAccessFacadeTests
  {
    [TestMethod]
    public void AddingRetroItemTest()
    {
      IRetroItemsDataAccessFacade retroItemsDataAccessFacade = new RetroItemsDataAccessFacade();

      const string TestMessage = "testItem";

      retroItemsDataAccessFacade.Adder.AddRetroItem(TestMessage);

      var result = retroItemsDataAccessFacade.Provider.GetRetroItems();

      CollectionAssert.Contains(result.ToList(), TestMessage);
    }
  }
}
