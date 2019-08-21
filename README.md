# Tiny encryption tool

Easy to use with dependency injection containers:

```csharp
using TinyEncryptor;
/// required to instantiate RNGCryptoServiceProvider
using System.Security.Cryptography;

RandomNumberGenerator generator = new RNGCryptoServiceProvider();

RandomBytesBuilder saltBuilder = new RandomBytesBuilderImpl(generator);
saltBuilder.setLength(48);
byte[] salt = saltBuilder.build();


byte[] password = System.Text.Encoding.UTF8.GetBytes("P@ssw0rd");
SaltBasedHashBuilder builder = new SaltBasedHashBuilderImpl();

builder.setLength(55);
builder.setIterations(3492);
builder.setHashAlgorithm("SHA384");
builder.setSalt(salt);
builder.setOriginal(password);

byte[] passwordHash = builder.build();
```