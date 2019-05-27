using System;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace EasyEncrypt
{
  public class SaltBasedHashBuilderImpl : SaltBasedHashBuilder
  {
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
      Rfc2898DeriveBytes factory = new Rfc2898DeriveBytes(
        this.original,
        this.salt,
        this.iterations,
        this.hashAlgorithmName
      );

      byte[] result = factory.GetBytes(this.length);

      return result;
    }

    private HashAlgorithmName hashAlgorithmName;
    public void setHashAlgorithm(string name)
    {
      if(string.IsNullOrEmpty(name))
        throw new ArgumentNullException("name");
      
      if(string.IsNullOrWhiteSpace(name))
        throw new ArgumentNullException("name");

      if(!algorithms.ContainsKey(name))
      {
        string message = 
          String.Format("Unknown hash algorithm name {0}!", name);
        throw new ArgumentOutOfRangeException("name", name, message);
      }

      this.hashAlgorithmName = algorithms[name];
    }

    private int iterations;
    public void setIterations(int value)
    {
      this.validateInteger(value, "iterations");
      this.iterations = value;
    }

    private int length;
    public void setLength(int value)
    {
      this.validateInteger(value, "length");
      this.length = value;
    }

    private void validateInteger(int value, string name)
    {
      string message = String.Format("{0} value must be positive integer!", name);

      if(value <= 0)
        throw new ArgumentOutOfRangeException(name, value, message);
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