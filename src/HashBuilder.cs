namespace TinyEncryptor
{
  public interface HashBuilder
  {
    void setLength(int value);
    void setIterations(int value);
    void setOriginal(byte[] value);
    void setHashAlgorithm(string name);
    byte[] build();
  }
}