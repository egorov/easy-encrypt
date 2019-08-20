using System;
using EasyEncrypt;
using Xunit;

namespace Tests
{
  public class SaltBasedHashBuilderImplTests
  {
    private SaltBasedHashBuilder builder;
    private int length;
    private byte[] salt;
    private int iterations;
    private string hashAlgorithm;
    private byte[] original;

    public SaltBasedHashBuilderImplTests()
    {
      this.builder = new SaltBasedHashBuilderImpl();

      this.length = 64;
      this.salt = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 };
      this.iterations = 1000;
      this.hashAlgorithm = "SHA512";
      this.original = System.Text.Encoding.UTF8.GetBytes("P@ssw0rd");

      this.builder.setLength(this.length);
      this.builder.setIterations(this.iterations);
      this.builder.setHashAlgorithm(this.hashAlgorithm);
      this.builder.setSalt(salt);
      this.builder.setOriginal(original);
    }

    [Fact]
    public void same_salt_should_produce_same_hash()
    {           
      byte[] first = this.builder.build();
      byte[] second = this.builder.build();

      Assert.Equal(length, first.Length);
      Assert.Equal(length, second.Length);

      for(int i = 0; i < first.Length; i++)
      {
        Assert.Equal(first[i], second[i]);
      }
    }

    [Fact]
    public void different_salt_should_produce_different_hash()
    {
      byte[] first = this.builder.build();

      byte[] anotherSalt = new byte[] { 8, 7, 6, 5, 4, 3, 2, 1 };
      this.builder.setSalt(anotherSalt);
      byte[] second = this.builder.build();

      Assert.Equal(length, first.Length);
      Assert.Equal(length, second.Length);
      
      Assert.NotSame(first, second);

      for(int i = 0; i < first.Length; i++)
      {
        Assert.NotEqual(first[i], second[i]);
      }
    }

    [Fact]
    public void should_throw_setLength()
    {
      Action negativeLength = () => this.builder.setLength(-1);
      Assert.Throws<ArgumentOutOfRangeException>(negativeLength);

      Action zeroLength = () => this.builder.setLength(0);
      Assert.Throws<ArgumentOutOfRangeException>(zeroLength);
    }

    [Fact]
    public void should_throw_setIterations()
    {
      Action negativeLength = () => this.builder.setIterations(-1);
      Assert.Throws<ArgumentOutOfRangeException>(negativeLength);

      Action zeroLength = () => this.builder.setIterations(0);
      Assert.Throws<ArgumentOutOfRangeException>(zeroLength);
    }

    [Fact]
    public void should_throw_setHashAlgorithm()
    {
      Action nullName = () => this.builder.setHashAlgorithm(null);
      Assert.Throws<ArgumentNullException>(nullName);

      Action emptyName = () => this.builder.setHashAlgorithm("");
      Assert.Throws<ArgumentNullException>(emptyName);      

      Action whitespaceName = () => this.builder.setHashAlgorithm(" ");
      Assert.Throws<ArgumentNullException>(whitespaceName);      
    }

    [Fact]
    public void should_throw_setOriginal()
    {
      Action nullOriginal = () => this.builder.setOriginal(null);
      Assert.Throws<ArgumentNullException>(nullOriginal);

      Action emptyOriginal = () => this.builder.setOriginal(new byte[] {});
      Assert.Throws<ArgumentException>(emptyOriginal);
    }

    [Fact]
    public void should_throw_setSalt()
    {
      Action nullSalt = () => this.builder.setSalt(null);
      Assert.Throws<ArgumentNullException>(nullSalt);

      Action emptySalt = () => this.builder.setSalt(new byte[] {});
      Assert.Throws<ArgumentException>(emptySalt);
    }
  }
}