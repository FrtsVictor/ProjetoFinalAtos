namespace Np.Cryptography;

public interface ICryptography
{
    string Encrypt(string key, string input);
}