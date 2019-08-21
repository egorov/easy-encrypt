using System.Collections.Generic;
using System.Security.Cryptography;

namespace TinyEncryptor
{
  public class HashAlgorithmNameDictionary : Dictionary<string, HashAlgorithmName>
  {
    public HashAlgorithmNameDictionary()
    {
      this.Add("MD5", HashAlgorithmName.MD5);
      this.Add("SHA1", HashAlgorithmName.SHA1);
      this.Add("SHA256", HashAlgorithmName.SHA256);
      this.Add("SHA384", HashAlgorithmName.SHA384);
      this.Add("SHA512", HashAlgorithmName.SHA512);
    }
  }
}