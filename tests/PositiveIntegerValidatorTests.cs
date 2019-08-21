using System;
using Checking;
using TinyEncryptor;
using Xunit;

namespace Tests
{
  public class PositiveIntegerValidatorTests
  {
    private ObjectValidator validator;

    public PositiveIntegerValidatorTests()
    {
      this.validator = new PositiveIntegerValidator();
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(0)]
    private void should_throw(object value)
    {
      Action validate = () => this.validator.validate(value);

      ArgumentOutOfRangeException error = 
        Assert.Throws<ArgumentOutOfRangeException>(validate);

      Assert.StartsWith("value must be positive integer!", error.Message);
      Assert.Contains("Parameter name: value", error.Message);
      
      string suffix = $"Actual value was {value}.";
      Assert.EndsWith(suffix, error.Message);
    }

    [Theory]
    [InlineData("text")]
    [InlineData(true)]
    [InlineData(10L)]
    private void should_throw_ArgumentException(object value)
    {
      Action validate = () => this.validator.validate(value);

      ArgumentException error = Assert.Throws<ArgumentException>(validate);

      Assert.Equal("value must be positive integer!", error.Message);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(100)]
    [InlineData(281)]
    public void should_pass(object value)
    {
      this.validator.validate(value);
    }
  }
}