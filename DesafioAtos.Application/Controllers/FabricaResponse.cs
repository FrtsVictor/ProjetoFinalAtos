namespace DesafioAtos.Application.Controllers
{
    public class FabricaResponse : IFabricaResponse
    {
<<<<<<< HEAD
        public object Criar(string message) => new {message = message};
        public object Criar<T>(T data) => new {data = data};
        public object Criar<T>(string message, T data) => new {message = message, data = data};
=======
        public object Criar(string message) => new { message = message };
        public object Criar<T>(T data) => new { data = data };
        public object Criar<T>(string message, T data) => new { message = message, data = data };
>>>>>>> a4c0c85 (datanotation)
    }
}

