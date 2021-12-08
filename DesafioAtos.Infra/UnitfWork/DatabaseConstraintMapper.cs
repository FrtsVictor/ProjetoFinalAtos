using DesafioAtos.Infra.Exceptions;
using Microsoft.Extensions.Logging;

namespace DesafioAtos.Infra.Mapping
{
    public class DatabaseConstraintMapper : IDatabaseConstraintMapper
    {
        private readonly ILogger<DatabaseConstraintMapper> _logger;
        public DatabaseConstraintMapper(ILogger<DatabaseConstraintMapper> logger)
        {
            this._logger = logger;
        }

        private static readonly Dictionary<string, string> ConstraintKeyAndErrorMessage = new Dictionary<string, string>()
        {
            {"IX_Users_Username", "Username already in use! Try another username"},
            {"'Username'. Truncated value:", "Please check maximum length of username"}
        };

        public void Map(Exception ex)
        {
            string errorMessage = ex.InnerException?.Message ?? ex.Message;
            _logger.LogError(errorMessage);

            foreach (KeyValuePair<string, string> pair in ConstraintKeyAndErrorMessage)
            {
                if (errorMessage.ToLower().Contains(pair.Key.ToLower()))
                {
                    throw new DataBaseConstraintException(pair.Value, ex);
                }
            }
        }
    }
}
