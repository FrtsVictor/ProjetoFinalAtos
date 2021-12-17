using System;
using System.Security.Cryptography;
using Np.Cryptography;
using Xunit;

namespace Test;

public class TestCriptografo
{
    [Fact]
    public void ShouldEncrypt()
    {
        var cryptography = new Criptografo();
        const string inputToBeEncrypted = "input to be encrypted";
        var encryptedInput = cryptography.Criptografar("asdasda213d123wq", inputToBeEncrypted);

        Assert.NotEqual(inputToBeEncrypted, encryptedInput);
    }

    [Fact]
    public void ShouldDecrypt()
    {
        var cryptography = new Criptografo();
        const string encryptPattern = "VGVzdEtleUF0b3NfVGVzdEtleUF0b3M=";
        const string inputToBeEncrypted = "Server=127.0.0.1;Database=project_final;User Id=sa;Password=yourStrong(!)Password;";
        var encryptedInput = cryptography.Criptografar(encryptPattern, inputToBeEncrypted);
        var decryptedOutput = cryptography.Descriptografar(encryptPattern, encryptedInput);

        Assert.NotEqual(encryptedInput, decryptedOutput);
    }

    [Fact]
    public void ShouldEncryptSuccessfullyWhenEncryptPatternAndDecryptPatternAreCorrect()
    {
        var cryptography = new Criptografo();
        const string encryptPattern = "asdasdasd";
        const string inputToBeEncrypted = "input to be encrypted";
        var encryptedInput = cryptography.Criptografar(encryptPattern, inputToBeEncrypted);
        var decryptedOutput = cryptography.Descriptografar(encryptPattern, encryptedInput);

        Assert.Equal(inputToBeEncrypted, decryptedOutput);
    }

    [Fact]
    public void ShouldThrowCryptographyExceptionWhenEncryptPatternIsDifferentFromUsed()
    {
        var cryptography = new Criptografo();
        const string inputToBeEncrypted = "input to be encrypted";
        var encryptedPassword = cryptography.Criptografar("fsfsdgsasd", inputToBeEncrypted);

        Assert.Throws<CryptographicException>(() => cryptography.Descriptografar("fasdqdaasdq", encryptedPassword));
    }

    [Fact]
    public void ShouldThrowCryptographyExceptionWhenEncryptPatternIsNullOrEmpty()
    {
        var cryptography = new Criptografo();
        Assert.Throws<ArgumentException>(() => cryptography.Criptografar("", "input"));
        Assert.Throws<ArgumentException>(() => cryptography.Criptografar(null!, "input"));
    }

    [Fact]
    public void ShouldThrowCryptographyExceptionWhenEncryptInputIsNullOrEmpty()
    {
        var cryptography = new Criptografo();
        Assert.Throws<ArgumentException>(() => cryptography.Criptografar("MyPattern", ""));
        Assert.Throws<ArgumentException>(() => cryptography.Criptografar("MyPattern", null!));
    }

    [Fact]
    public void ShouldThrowCryptographyExceptionWhenDecryptPatternIsNullOrEmpty()
    {
        var cryptography = new Criptografo();
        Assert.Throws<ArgumentException>(() => cryptography.Descriptografar("", "input"));
        Assert.Throws<ArgumentException>(() => cryptography.Descriptografar(null!, "input"));
    }

    [Fact]
    public void ShouldThrowCryptographyExceptionWhenDecryptInputIsNullOrEmpty()
    {
        var cryptography = new Criptografo();
        Assert.Throws<ArgumentException>(() => cryptography.Descriptografar("", "input"));
        Assert.Throws<ArgumentException>(() => cryptography.Descriptografar(null!, "input"));
    }


}