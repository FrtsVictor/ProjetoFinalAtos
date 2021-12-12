namespace DesafioAtos.Domain.Core
{
    public interface IAppConfigEcoleta
    {
        string ConnectionString();
        string JwtKey();
        string PasswordKey();
    }
}