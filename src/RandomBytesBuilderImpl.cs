using System;
using System.Security.Cryptography;

namespace EasyEncrypt
{
  public class RandomBytesBuilderImpl : RandomBytesBuilder
  {
    private RandomNumberGenerator generator;
    public RandomBytesBuilderImpl(RandomNumberGenerator generator)
    {
      this.generator = generator;
    }

    private static readonly string message = "must be positive integer!";
    private int length;
    public void setLength(int length)
    {
      if(length <= 0)
        throw new ArgumentOutOfRangeException(nameof(length), length, message);

      this.length = length;
    }

    public byte[] build()
    {
      this.validateLength();

      byte[] result = new byte[this.length];

      this.generator.GetBytes(result);

      return result;
    }

    private void validateLength()
    {
      if(this.length <= 0)
        throw new InvalidOperationException("Call setLength(int) first!");        
    }
  }
}
