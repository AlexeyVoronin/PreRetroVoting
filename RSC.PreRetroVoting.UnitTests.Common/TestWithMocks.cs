using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NMock;

namespace RSC.PreRetroVoting.UnitTests.Common
{
  [TestClass]
  public abstract class TestWithMocks : IDisposable
  {
    [TestInitialize]
    public void TestInitialize()
    {
      if (MockFactory != null)
        return;

      MockFactory = new MockFactory();
    }

    [TestCleanup]
    public void TestCleanUp()
    {
      MockFactory.VerifyAllExpectationsHaveBeenMet();
    }

    public void Dispose()
    {
      if (MockFactory == null)
        return;

      MockFactory.Dispose();
    }

    protected MockFactory MockFactory { get; private set; }
  }
}
