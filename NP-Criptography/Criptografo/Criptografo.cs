using System.Security.Cryptography;

#pragma warning disable CS0618

namespace Np.Cryptography;

public sealed class Criptografo : ICriptografo
{
    private readonly byte[] _salt;

    public Criptografo()
    {
        _salt = GetSalt();
    }

    private static byte[] GetSalt() => new byte[]
    {
        0x43, 0x71, 0x80, 0x2F, 0x1E, 0x6E, 0x2B, 0x86, 0x24,
        0x21, 0x68, 0x9E, 0x09, 0x42, 0x92, 0x23, 0x53, 0x49,
        0x13, 0x5E, 0x76, 0x97, 0x64, 0x86, 0x1D, 0x16, 0x39,
        0x61, 0x37, 0x69, 0x25, 0x75, 0x86, 0x45, 0x20, 0x14,
    };

    private Rfc2898DeriveBytes GetSaltPassword(string password) => new Rfc2898DeriveBytes(password, _salt);

    private static byte[] GetKey(DeriveBytes saltPassword) => saltPassword.GetBytes(32);

    private static byte[] GetIv(DeriveBytes saltPassword) => saltPassword.GetBytes(16);

    public string Criptografar(string encryptPattern, string input)
    {
        ValidarEntradaDeDados(encryptPattern, input);
        var saltPassword = GetSaltPassword(encryptPattern);

        using var aesService = new AesCryptoServiceProvider();
        aesService.Key = GetKey(saltPassword);
        aesService.IV = GetIv(saltPassword);
        var encryptor = aesService.CreateEncryptor(aesService.Key, aesService.IV);

        using var stream = new MemoryStream();
        using var cryptoStream = new CryptoStream(stream, encryptor, CryptoStreamMode.Write);
        using (var writer = new StreamWriter(cryptoStream))
        {
            writer.Write(input);
        }

        return Convert.ToBase64String(stream.ToArray());
    }

    public string Descriptografar(string decryptPattern, string input)
    {
        ValidarEntradaDeDados(decryptPattern, input);
        var byteText = Convert.FromBase64String(input);
        var saltPassword = GetSaltPassword(decryptPattern);

        using var aesService = new AesCryptoServiceProvider();
        aesService.Key = GetKey(saltPassword);
        aesService.IV = GetIv(saltPassword);
        var decrypt = aesService.CreateDecryptor(aesService.Key, aesService.IV);

        using var stream = new MemoryStream(byteText);
        using var cryptoStream = new CryptoStream(stream, decrypt, CryptoStreamMode.Read);
        using var reader = new StreamReader(cryptoStream);
        return reader.ReadToEnd();
    }

    private static void ValidarEntradaDeDados(params string[] @params)
    {
        if (@params.Any(string.IsNullOrEmpty))
        {
            throw new ArgumentException("Value can't be null or empty.");
        }
    }
}