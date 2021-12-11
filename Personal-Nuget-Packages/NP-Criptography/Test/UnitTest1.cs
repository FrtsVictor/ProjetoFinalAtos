using System;
using System.Security.Cryptography;
using Np.Cryptography;
using Xunit;

namespace Test;

public class UnitTest1
{
    [Fact]
    public void ShouldEncrypt()
    {
        var cryptography = new Cryptography();
        const string inputToBeEncrypted = "input to be encrypted";
        string encryptedInput = cryptography.Encrypt("asdasda213d123wq", inputToBeEncrypted);

        Assert.NotEqual(inputToBeEncrypted, encryptedInput);
    }

    [Fact]
    public void ShouldDecrypt()
    {
        var cryptography = new Cryptography();
        const string encryptPattern = "VGVzdEtleUF0b3NfVGVzdEtleUF0b3M=";
        const string inputToBeEncrypted = "Server=127.0.0.1;Database=projeto_final;User Id=sa;Password=yourStrong(!)Password;";
        string encryptedInput = cryptography.Encrypt(encryptPattern, inputToBeEncrypted);
        string decryptedOutput = cryptography.Decrypt(encryptPattern, encryptedInput);

        Assert.NotEqual(encryptedInput, decryptedOutput);
    }

    [Fact]
    public void ShouldEncryptSuccessfullyWhenEncryptPatternAndDecryptPatternAreCorrect()
    {
        var cryptography = new Cryptography();
        const string encryptPattern = "asdasdasd";
        const string inputToBeEncrypted = "input to be encrypted";
        string encryptedInput = cryptography.Encrypt(encryptPattern, inputToBeEncrypted);
        string decryptedOutput = cryptography.Decrypt(encryptPattern, encryptedInput);

        Assert.Equal(inputToBeEncrypted, decryptedOutput);
    }

    [Fact]
    public void ShouldThrowCryptographyExceptionWhenEncryptPatternIsDifferentFromUsed()
    {
        var cryptography = new Cryptography();
        const string inputToBeEncrypted = "input to be encrypted";
        string encryptedPassword = cryptography.Encrypt("fsfsdgsasd", inputToBeEncrypted);

        Assert.Throws<CryptographicException>(() => cryptography.Decrypt("fasdqdaasdq", encryptedPassword));
    }

    [Fact]
    public void ShouldThrowCryptographyExceptionWhenEncryptPatternIsNullOrEmpty()
    {
        var cryptography = new Cryptography();
        Assert.Throws<ArgumentException>(() => cryptography.Encrypt("", "input"));
        Assert.Throws<ArgumentException>(() => cryptography.Encrypt(null, "input"));
    }

    [Fact]
    public void ShouldThrowCryptographyExceptionWhenEncryptInputIsNullOrEmpty()
    {
        var cryptography = new Cryptography();
        Assert.Throws<ArgumentException>(() => cryptography.Encrypt("MyPattern", ""));
        Assert.Throws<ArgumentException>(() => cryptography.Encrypt("MyPattern", null));
    }

    [Fact]
    public void ShouldThrowCryptographyExceptionWhenDecryptPatternIsNullOrEmpty()
    {
        var cryptography = new Cryptography();
        Assert.Throws<ArgumentException>(() => cryptography.Decrypt("", "input"));
        Assert.Throws<ArgumentException>(() => cryptography.Decrypt(null, "input"));
    }

    [Fact]
    public void ShouldThrowCryptographyExceptionWhenDecryptInputIsNullOrEmpty()
    {
        var cryptography = new Cryptography();
        Assert.Throws<ArgumentException>(() => cryptography.Decrypt("", "input"));
        Assert.Throws<ArgumentException>(() => cryptography.Decrypt(null, "input"));
    }


}