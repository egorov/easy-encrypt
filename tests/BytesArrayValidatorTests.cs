using Xunit;
using Checking;
using System;
using TinyEncryptor;

namespace Tests
{
  public class BytesArrayValidatorTests
  {
    private ObjectValidator validator;

    public BytesArrayValidatorTests()
    {
      this.validator = new BytesArrayValidator();
    }

    [Fact]
    public void should_throw()
    {
      Action nullArray = () => this.validator.validate(null);
      Assert.Throws<ArgumentException>(nullArray);

      Action zeroSizeArray = () => this.validator.validate(new byte[0]);
      Assert.Throws<ArgumentException>(zeroSizeArray);

      Action notBytesArray = () => this.validator.validate("bytes array");
      Assert.Throws<ArgumentException>(notBytesArray);
    }

    [Fact]
    public void should_pass()
    {
      this.validator.validate(new byte[] { 1, 2, 3 });
      this.validator.validate(new byte[10]);
    }
  }
}