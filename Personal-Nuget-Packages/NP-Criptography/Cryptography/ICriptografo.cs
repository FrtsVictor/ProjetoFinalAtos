namespace Np.Cryptography;

public interface ICriptografo
{
    string Criptografar(string key, string input);
    string Descriptografar(string key, string input);
}