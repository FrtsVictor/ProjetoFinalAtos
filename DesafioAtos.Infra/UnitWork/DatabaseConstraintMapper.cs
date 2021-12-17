using DesafioAtos.Infra.Exceptions;
using Microsoft.Extensions.Logging;

namespace DesafioAtos.Infra.UnitWork
{
    public class DatabaseConstraintMapper : IDatabaseConstraintMapper
    {
        private readonly ILogger<DatabaseConstraintMapper> _logger;
        public DatabaseConstraintMapper(ILogger<DatabaseConstraintMapper> logger)
        {
            this._logger = logger;
        }

        private static readonly Dictionary<string, string> ConstraintKeyAndErrorMessage =
            new Dictionary<string, string>()
            {
                {"'Username'. Truncated value:", "Verifique o login."},
                {"UNIQUE KEY constraint 'UQ__Usuario__7838F2722B998160'", "Usuario existente, tente outro login."},
                {"UNIQUE KEY constraint 'UQ__Empresa___35BD3E48FBD7C33E'", "Cnpj ja cadastrado, tente outro cnpj."},
                {"'telefone'. Truncated value:", "Verifique o numero de telefone."},
                {"UNIQUE KEY constraint 'UQ__Empresa___2A16D97F4BD0B9D7'", "Telefone ja cadastrado."},
                {"UQ__Empresa___AB6E6164358524FB", "Email ja cadastrado ja cadastrado."},
                {"'numero'. Truncated value:", "Verifique o numero do endereco."},
                {"'cep'. Truncated value", "Verifique o cep do endereco."}
            };

        public void Map(Exception ex)
        {
            var errorMessage = ex.InnerException?.Message ?? ex.Message;
            _logger.LogError(errorMessage);

            foreach (var pair in ConstraintKeyAndErrorMessage.Where(pair =>
                         errorMessage.ToLower().Contains(pair.Key.ToLower())))
            {
                throw new DataBaseConstraintException(pair.Value, ex);
            }
        }
    }
}
