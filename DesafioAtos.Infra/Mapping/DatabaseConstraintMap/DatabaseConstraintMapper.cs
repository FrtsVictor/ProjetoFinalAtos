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
                {"'Username'. Truncated value:", "Verifique o tamanho do login."},
                {"'telefone'. Truncated value:", "Verifique o tamanho numero de telefone."},
                {"'numero'. Truncated value:", "Verifique o tamanho do numero de endereco."},
                {"'cep'. Truncated value", "Verifique o tamanho do cep de endereco."},
                {"Usuario_Constraint_UNIQUE_Login", "Usuario existente, tente outro login."},
                {"Empresa_Coletora_Constraint_UNIQUE_Cnpj", "Cnpj empresa ja cadastrado, tente outro cnpj."},
                {"Empresa_Coletora_Constraint_UNIQUE_Telefone", "Telefone empresa ja cadastrado, tente outro telefone."},
                {"Empresa_Coletora_Constraint_UNIQUE_Email", "Email empresa ja cadastrado ja cadastrado, tente outro email."},
                {"Empresa_Coletora_Constraint_UNIQUE_Nome", "Nome empresa ja cadastrado ja cadastrado, tente outro nome."},
                {"Categoria_Constraint_Unique_Nome", "Nome ja cadastrado ja cadastrado, tente outro nome."}
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
