using Xunit;
using TinyEncryptor;
using System.Security.Cryptography;

namespace Tests
{
  public class EncryptionToolsImplTests
  {
    private RandomBytesBuilder saltBuilder;
    private SaltBasedHashBuilder hashBuilder;
    private EncryptionTools tools;
    public EncryptionToolsImplTests()
    {
      this.saltBuilder = 
        new RandomBytesBuilderImpl(new RNGCryptoServiceProvider());
      this.hashBuilder = new SaltBasedHashBuilderImpl();
      this.tools = new EncryptionToolsImpl(
        this.saltBuilder,
        this.hashBuilder
      );
    }

    [Fact]
    public void should_supply_RandomBytesBuilder()
    {
      Assert.Equal(this.saltBuilder, this.tools.SaltBuilder);
    }

    [Fact]
    public void should_supply_SaltBasedHashBuilder()
    {
      Assert.Equal(this.hashBuilder, this.tools.HashBuilder);
    }
  }
}