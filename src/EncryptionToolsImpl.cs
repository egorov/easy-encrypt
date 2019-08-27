using Checking;

namespace TinyEncryptor
{
  public class EncryptionToolsImpl : EncryptionTools
  {
    private Value<RandomBytesBuilder> saltBuilderValue;
    private Value<SaltBasedHashBuilder> hashBuilderValue;
    public EncryptionToolsImpl(
      RandomBytesBuilder saltBuilder,
      SaltBasedHashBuilder hashBuilder
    )
    {
      this.saltBuilderValue = new ValueAdapter<RandomBytesBuilder>(saltBuilder);
      this.hashBuilderValue = new ValueAdapter<SaltBasedHashBuilder>(hashBuilder);
    }

    public RandomBytesBuilder SaltBuilder {
      get {
        return this.saltBuilderValue.get();
      }
    }

    public SaltBasedHashBuilder HashBuilder {
      get {
        return this.hashBuilderValue.get();
      }
    }
  }
}