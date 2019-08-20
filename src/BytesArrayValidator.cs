using System;
using Checking;

namespace EasyEncrypt
{
  public class BytesArrayValidator : ObjectValidator
  {
    private static readonly string message = "value must be an array of non-zero bytes!";

    public void validate(object value)
    {
      if(!(value is byte[]))
        throw new ArgumentException(message);

      byte[] v = value as byte[];

      if(v.Length == 0)
        throw new ArgumentException(message);
    }
  }
}