using Checking;

namespace EasyEncrypt
{
  public class ValidatorsImpl : ObjectValidators
  {
    public ValidatorsImpl()
    {
      this.Add(typeof(int), new PositiveIntegerValidator());
    }    
  }
}