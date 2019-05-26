using System;
using EasyEncrypt;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
  [TestClass]
  public class RandomBytesBuilderImplTests
  {
    private RandomBytesBuilder builder;

    [TestInitialize]
    public void setUp()
    {
      this.builder = new RandomBytesBuilderImpl();
    }

    [TestMethod]
    public void should_build_random_bytes()
    {
      int length = 10;
      this.builder.setLength(length);

      byte[] first = this.builder.build();
      byte[] second = this.builder.build();

      Assert.AreNotEqual(first, second);
      Assert.AreNotSame(first, second);
    }

    [TestMethod]
    public void should_throw()
    {
      Action lengthBelowZero = () => this.builder.setLength(-1);
      Assert.ThrowsException<ArgumentOutOfRangeException>(lengthBelowZero);

      Action zeroLength = () => this.builder.setLength(0);
      Assert.ThrowsException<ArgumentOutOfRangeException>(zeroLength);

      Action lengthIsNotSet = () => this.builder.build();
      Assert.ThrowsException<InvalidOperationException>(lengthIsNotSet);
    }
  }
}
