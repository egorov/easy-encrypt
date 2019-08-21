using System;
using System.Security.Cryptography;
using Checking;

namespace TinyEncryptor
{
  public class SaltBasedHashBuilderImpl : SaltBasedHashBuilder
  {
    private static readonly CustomValidators customValidators = 
      new ValidatorsImpl();
    private static readonly HashAlgorithmNameDictionary algorithms = 
      new HashAlgorithmNameDictionary();
    private Value<int> lengthValue;
    private Value<int> iterationsValue;
    private Value<string> algorithmName;
    private Value<HashAlgorithmName> algorithmValue;
    private Value<byte[]> originalValue;
    private Value<byte[]> saltValue;
    public SaltBasedHashBuilderImpl()
    {
      this.lengthValue = new ValueContainer<int>(customValidators);      
      this.iterationsValue = new ValueContainer<int>(customValidators);
      this.algorithmName = new ValueContainer<string>();
      this.algorithmValue = new ValueContainer<HashAlgorithmName>();
      this.originalValue = new ValueContainer<byte[]>(customValidators);
      this.saltValue = new ValueContainer<byte[]>(customValidators);
    }

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