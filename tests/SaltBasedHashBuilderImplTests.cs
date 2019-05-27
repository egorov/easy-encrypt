using System;
using EasyEncrypt;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
  [TestClass]
  public class SaltBasedHashBuilderImplTests
  {
    private SaltBasedHashBuilder builder;

    [TestInitialize]
    public void setUp()
    {
      this.builder = new SaltBasedHashBuilderImpl();
    }

    [TestMethod]
    public void should_build_same_hash()
    {
      int length = 64;
      this.builder.setLength(length);
      this.builder.setIterations(1000);
      this.builder.setHashAlgorithm("SHA512");
      
      byte[] salt = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 };
      this.builder.setSalt(salt);
      
      byte[] original = System.Text.Encoding.UTF8.GetBytes("P@ssw0rd");
      this.builder.setOriginal(original);

      byte[] first = this.builder.build();
      byte[] second = this.builder.build();

      Assert.AreEqual(length, first.Length);
      Assert.AreEqual(length, second.Length);

      for(int i = 0; i < first.Length; i++)
      {
        Assert.AreEqual(first[i], second[i]);
      }
    }

    [TestMethod]
    public void should_throw_setLength()
    {
      Action negativeLength = () => this.builder.setLength(-1);
      Assert.ThrowsException<ArgumentOutOfRangeException>(negativeLength);

      Action zeroLength = () => this.builder.setLength(0);
      Assert.ThrowsException<ArgumentOutOfRangeException>(zeroLength);
    }

    [TestMethod]
    public void should_throw_setIterations()
    {
      Action negativeLength = () => this.builder.setIterations(-1);
      Assert.ThrowsException<ArgumentOutOfRangeException>(negativeLength);

      Action zeroLength = () => this.builder.setIterations(0);
      Assert.ThrowsException<ArgumentOutOfRangeException>(zeroLength);
    }

    [TestMethod]
    public void should_throw_setHashAlgorithm()
    {
      Action nullName = () => this.builder.setHashAlgorithm(null);
      Assert.ThrowsException<ArgumentNullException>(nullName);

      Action emptyName = () => this.builder.setHashAlgorithm("");
      Assert.ThrowsException<ArgumentNullException>(emptyName);      

      Action whitespaceName = () => this.builder.setHashAlgorithm(" ");
      Assert.ThrowsException<ArgumentNullException>(whitespaceName);      
    }
  }
}