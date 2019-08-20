using System;
using EasyEncrypt;
using Xunit;
using System.Security.Cryptography;

namespace Tests
{
  public class RandomBytesBuilderImplTests
  {
    private RandomBytesBuilder builder;

    public RandomBytesBuilderImplTests()
    {
      this.builder = new RandomBytesBuilderImpl(new RNGCryptoServiceProvider());
    }

    [Fact]
    public void should_build_random_bytes()
    {
      int length = 10;
      this.builder.setLength(length);

      byte[] first = this.builder.build();
      byte[] second = this.builder.build();

      Assert.Equal(length, first.Length);
      Assert.Equal(length, second.Length);
      Assert.NotEqual(first, second);
      Assert.NotSame(first, second);
    }

    [Fact]
    public void should_throw()
    {
      Action lengthBelowZero = () => this.builder.setLength(-1);
      Assert.Throws<ArgumentOutOfRangeException>(lengthBelowZero);

      Action zeroLength = () => this.builder.setLength(0);
      Assert.Throws<ArgumentOutOfRangeException>(zeroLength);

      Action lengthIsNotSet = () => this.builder.build();
      Assert.Throws<InvalidOperationException>(lengthIsNotSet);
    }
  }
}
