namespace DesafioAtos.Application.Controllers
{
    /// <inheritdoc />
    public class FabricaResponse : IFabricaResponse
    {
        /// <inheritdoc />
        public object Criar(string message) => new {message = message};

        /// <inheritdoc />
        public object Criar<T>(T data) => new {data = data};

        /// <inheritdoc />
        public object Criar<T>(string message, T data) => new {message = message, data = data};
    }
}

