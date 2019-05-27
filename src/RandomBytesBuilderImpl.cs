using System;
using System.Security.Cryptography;

namespace EasyEncrypt
{
  public class RandomBytesBuilderImpl : RandomBytesBuilder
  {
    private RandomNumberGenerator randomNumberGenerator;
    public RandomBytesBuilderImpl()
    {
      this.randomNumberGenerator = new RNGCryptoServiceProvider();
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

      this.randomNumberGenerator.GetBytes(result);

      return result;
    }

    private void validateLength()
    {
      if(this.length <= 0)
        throw new InvalidOperationException("Call setLength(int) first!");        
    }
  }
}
