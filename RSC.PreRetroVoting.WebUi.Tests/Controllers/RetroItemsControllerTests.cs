using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RSC.PreRetroVoting.DataAccess;
using RSC.PreRetroVoting.WebUi.Controllers;

namespace RSC.PreRetroVoting.WebUi.Tests.Controllers
{
  [TestClass]
  public class RetroItemsControllerTests
  {
    [TestMethod]
    public void List()
    {
      var repositoryMock = new Mock<IRetroItemsRepository>();
      repositoryMock.Setup(m => m.GetRetroItems())
        .Returns(new[] 
          {
            new RetroItem 
              {
                Id = Guid.NewGuid(), 
                Description = "1", 
                VoterNames = null
              },
            new RetroItem 
              {
                Id = Guid.NewGuid(), 
                Description = "2", 
                VoterNames = new[] { "A" }
              },
            new RetroItem 
              {
                Id = Guid.NewGuid(), 
                Description = "3", 
                VoterNames = new[] { "A", "B" }
              }
          });


      var retroItemsController = new RetroItemsController(repositoryMock.Object);
      var result = retroItemsController.List();

      Assert.IsNotNull(result);
      
      var model = result.Model as IEnumerable<RetroItem>;
      Assert.IsNotNull(model);

      Assert.AreEqual(3, model.Count(), "RetroItems count in the model is invalid.");
      Assert.AreEqual("3", model.ElementAt(0).Description, InvalidRetroItemsOrderMessage);
      Assert.AreEqual("2", model.ElementAt(1).Description, InvalidRetroItemsOrderMessage);
      Assert.AreEqual("1", model.ElementAt(2).Description, InvalidRetroItemsOrderMessage);

      repositoryMock.VerifyAll();
    }

    private const string InvalidRetroItemsOrderMessage =
      "RetroItems order is invalid.";
  }
}
