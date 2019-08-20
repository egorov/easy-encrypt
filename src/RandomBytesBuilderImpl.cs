using System;
using System.Security.Cryptography;
using Checking;

namespace EasyEncrypt
{
  public class RandomBytesBuilderImpl : RandomBytesBuilder
  {
    private Value<int> lengthValue;
    private Value<RandomNumberGenerator> generatorValue;
    public RandomBytesBuilderImpl(RandomNumberGenerator generator)
    {
      this.generatorValue = new ValueAdapter<RandomNumberGenerator>(generator);
      this.lengthValue = new ValueContainer<int>(new ValidatorsImpl());
    }

    public void setLength(int length)
    {
      this.lengthValue.set(length);
    }

    public byte[] build()
    {
      this.lengthValue.validate();

      byte[] result = new byte[this.lengthValue.get()];

      this.generatorValue.get().GetBytes(result);

      return result;
    }
  }
}
