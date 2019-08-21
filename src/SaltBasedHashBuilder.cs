namespace TinyEncryptor
{
  public interface SaltBasedHashBuilder : HashBuilder
  {
    void setSalt(byte[] value);
  }
}