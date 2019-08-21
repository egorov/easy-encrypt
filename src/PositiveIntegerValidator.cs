using System;
using Checking;

namespace TinyEncryptor
{
  public class PositiveIntegerValidator : ObjectValidator
  {
    private static readonly string message = "value must be positive integer!";
    public void validate(object value)
    {
      if(!(value is int))
        throw new ArgumentException(message);
      
      int v = (int)value;

      if(v <= 0)
        throw new ArgumentOutOfRangeException(nameof(value), value, message);
    }
  }
}