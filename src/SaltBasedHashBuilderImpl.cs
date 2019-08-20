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
    public SaltBasedHashBuilderImpl()
    {
      this.lengthValue = new ValueContainer<int>(new ValidatorsImpl());      
      this.iterationsValue = new ValueContainer<int>(new ValidatorsImpl());
      this.algorithmName = new ValueContainer<string>();
      this.algorithmValue = new ValueContainer<HashAlgorithmName>();
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

      Rfc2898DeriveBytes factory = new Rfc2898DeriveBytes(
        this.original,
        this.salt,
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

    private byte[] original;
    public void setOriginal(byte[] value)
    {
      this.validateBytes(value, "original");
      this.original = value;
    }

    private byte[] salt;
    public void setSalt(byte[] value)
    {
      this.validateBytes(value, "salt");      
      this.salt = value;
    }

    private void validateBytes(byte[] value, string name)
    {
      if(value == null)
        throw new ArgumentNullException("value");
      
      string message = 
        String.Format("{0} Length must be greater than zero!", name);

      if(value.Length == 0)
        throw new ArgumentException(message);
    }
  }
}