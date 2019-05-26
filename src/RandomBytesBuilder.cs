namespace EasyEncrypt
{
  public interface RandomBytesBuilder
  {
    void setLength(int length);
    byte[] build();
  }
}