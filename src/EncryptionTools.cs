namespace TinyEncryptor
{
  public interface EncryptionTools
  {
    RandomBytesBuilder SaltBuilder { get; }
    SaltBasedHashBuilder HashBuilder { get; }
  }
}