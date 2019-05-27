namespace EasyEncrypt
{
  public interface SaltBasedHashBuilder : HashBuilder
  {
    void setSalt(byte[] value);
  }
}