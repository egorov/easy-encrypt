using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using Checking;

namespace EasyEncrypt
{
  public class SaltBasedHashBuilderImpl : SaltBasedHashBuilder
  {
    private Value<int> lengthValue;
    private Value<int> iterationsValue;
    private Value<string> algorithmName;
    private Value<HashAlgorithmName> algorithmValue;
    private Value<byte[]> originalValue;
    private Value<byte[]> saltValue;
    public SaltBasedHashBuilderImpl()
    {
      this.lengthValue = new ValueContainer<int>(new ValidatorsImpl());      
      this.iterationsValue = new ValueContainer<int>(new ValidatorsImpl());
      this.algorithmName = new ValueContainer<string>();
      this.algorithmValue = new ValueContainer<HashAlgorithmName>();
      this.originalValue = new ValueContainer<byte[]>(new ValidatorsImpl());
      this.saltValue = new ValueContainer<byte[]>(new ValidatorsImpl());
    }
    private static Dictionary<string, HashAlgorithmName> algorithms =
      new Dictionary<string, HashAlgorithmName> {
        { "MD5", HashAlgorithmName.MD5 },
        { "SHA1", HashAlgorithmName.SHA1},
        { "SHA256", HashAlgorithmName.SHA256 },
        { "SHA384", HashAlgorithmName.SHA384 },
        { "SHA512", HashAlgorithmName.SHA512 }
      };

    public byte[] build()
    {
      this.lengthValue.validate();
      this.iterationsValue.validate();
      this.algorithmValue.validate();
      this.originalValue.validate();
      this.saltValue.validate();

      Rfc2898DeriveBytes factory = new Rfc2898DeriveBytes(
        this.originalValue.get(),
        this.saltValue.get(),
        this.iterationsValue.get(),
        this.algorithmValue.get()
      );

      byte[] result = factory.GetBytes(this.lengthValue.get());

      return result;
    }

    public void setHashAlgorithm(string name)
    {
      this.algorithmName.set(name);

      if(!algorithms.ContainsKey(name))
      {
        string message = 
          String.Format("Unknown hash algorithm name {0}!", name);
        throw new ArgumentOutOfRangeException("name", name, message);
      }

      this.algorithmValue.set(algorithms[name]);
    }

    public void setIterations(int value)
    {
      this.iterationsValue.set(value);
    }

    public void setLength(int value)
    {
      this.lengthValue.set(value);
    }

    public void setOriginal(byte[] value)
    {
      this.originalValue.set(value);
    }

    public void setSalt(byte[] value)
    {
      this.saltValue.set(value);
    }
  }
}