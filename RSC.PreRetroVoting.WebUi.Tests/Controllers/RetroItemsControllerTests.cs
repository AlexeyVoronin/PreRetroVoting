using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RSC.PreRetroVoting.DataAccess.Model;
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
            var retroItem1 = new RetroItem("1");
            var retroItem2 = new RetroItem("2");
            retroItem2.Vote("A");
            var retroItem3 = new RetroItem("3");
            retroItem2.Vote("A");
            retroItem2.Vote("B");

            repositoryMock.Setup(m => m.GetRetroItems()).Returns(new[] { retroItem1, retroItem2, retroItem3 });


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
