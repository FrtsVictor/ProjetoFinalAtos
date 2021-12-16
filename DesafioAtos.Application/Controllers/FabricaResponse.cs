namespace DesafioAtos.Application.Controllers
{
    public class FabricaResponse : IFabricaResponse
    {
        public object Criar(string message) => new { message = message };
        public object Criar<T>(T data) => new { data = data };
        public object Criar<T>(string message, T data) => new { message = message, data = data };
    }
}

