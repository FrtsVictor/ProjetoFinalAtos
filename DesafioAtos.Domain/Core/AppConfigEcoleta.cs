namespace DesafioAtos.Domain.Core
{
    public class AppConfigEcoleta
    {
        private string JwtK { get; set; } = null!;
        private string ConnectionStr { get; set; } = null!;
        private string PassK { get; set; } = null!;

        public AppConfigEcoleta(string connectionStr, string jwtK, string PassK)
        {
            this.JwtK = jwtK;
            this.PassK = PassK;
            this.ConnectionStr = connectionStr;
        }

        public string ConnectionString() => ConnectionStr;
        public string JwtKey() => JwtK;
        public string PasswordKey() => PassK;
    }
}