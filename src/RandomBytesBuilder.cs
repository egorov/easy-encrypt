namespace TinyEncryptor
{
  public interface RandomBytesBuilder
  {
    void setLength(int length);
    byte[] build();
  }
}