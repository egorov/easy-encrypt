namespace EasyEncrypt
{
  public interface HashBuilder : HashAlgorithmConsumer
  {
    void setLength(int value);
    void setIterations(int value);
    void setOriginal(byte[] value);
    byte[] build();
  }
}