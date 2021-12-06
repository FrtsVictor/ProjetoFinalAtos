using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;

namespace Np.Cryptography;

public sealed class Cryptography
{
    private readonly byte[] Salt;

    public Cryptography()
    {
        Salt = GenerateSalt();
    }

    private static byte[] GenerateSalt() => new byte[]
    {
        0x43, 0x71, 0x80, 0x2F, 0x1E, 0x6E, 0x2B, 0x86, 0x24,
        0x21, 0x68, 0x9E, 0x09, 0x42, 0x92, 0x23, 0x53, 0x49,
        0x13, 0x5E, 0x76, 0x97, 0x64, 0x86, 0x1D, 0x16, 0x39,
        0x61, 0x37, 0x69, 0x25, 0x75, 0x86, 0x45, 0x20, 0x14,
    };

    private Rfc2898DeriveBytes GetSaltPassword(string password) => new Rfc2898DeriveBytes(password, Salt);

    private static byte[] GetKey(DeriveBytes saltPassword) => saltPassword.GetBytes(32);

    private static byte[] GetIV(DeriveBytes saltPassword) => saltPassword.GetBytes(16);

    public string Encrypt(string encryptPattern, string input)
    {
        ValidateInputs(encryptPattern, input);
        var saltPassword = GetSaltPassword(encryptPattern);

        using var aesService = new AesCryptoServiceProvider();
        aesService.Key = GetKey(saltPassword);
        aesService.IV = GetIV(saltPassword);
        var encryptor = aesService.CreateEncryptor(aesService.Key, aesService.IV);

        using var stream = new MemoryStream();
        using var cryptoStream = new CryptoStream(stream, encryptor, CryptoStreamMode.Write);
        using (var writer = new StreamWriter(cryptoStream))
        {
            writer.Write(input);
        }

        return Convert.ToBase64String(stream.ToArray());
    }

    public string Decrypt(string decryptPattern, string input)
    {
        ValidateInputs(decryptPattern, input);
        byte[] byteText = Convert.FromBase64String(input);
        var saltPassword = GetSaltPassword(decryptPattern);

        using var aesService = new AesCryptoServiceProvider();
        aesService.Key = GetKey(saltPassword);
        aesService.IV = GetIV(saltPassword);
        var decrypt = aesService.CreateDecryptor(aesService.Key, aesService.IV);

        using var stream = new MemoryStream(byteText);
        using var cryptoStream = new CryptoStream(stream, decrypt, CryptoStreamMode.Read);
        using var reader = new StreamReader(cryptoStream);
        return  reader.ReadToEnd();
    }

    private static void ValidateInputs(params string[] @params)
    {
        if (@params.Any(string.IsNullOrEmpty))
        {
            throw new ArgumentException("Value can't be null or empty.");
        }
    }
}