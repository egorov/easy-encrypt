using Xunit;
using EasyEncrypt;
using System.Security.Cryptography;

namespace Tests
{
  public class HashAlgorithmNameDictionaryTests
  {
    private HashAlgorithmNameDictionary dictionary;

    public HashAlgorithmNameDictionaryTests()
    {
      this.dictionary = new HashAlgorithmNameDictionary();
    }

    [Fact]
    public void should_supply_MD5()
    {
      Assert.Equal(HashAlgorithmName.MD5, this.dictionary["MD5"]);
    }

    [Fact]
    public void should_supply_SHA1()
    {
      Assert.Equal(HashAlgorithmName.SHA1, this.dictionary["SHA1"]);
    }

    [Fact]
    public void should_supply_SHA256()
    {
      Assert.Equal(HashAlgorithmName.SHA256, this.dictionary["SHA256"]);
    }

    [Fact]
    public void should_supply_SHA384()
    {
      Assert.Equal(HashAlgorithmName.SHA384, this.dictionary["SHA384"]);
    }

    [Fact]
    public void should_supply_SHA512()
    {
      Assert.Equal(HashAlgorithmName.SHA512, this.dictionary["SHA512"]);
    }
  }
}