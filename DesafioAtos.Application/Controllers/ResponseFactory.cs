namespace DesafioAtos.Application.Controllers
{
    public class ResponseFactory : IResponseFactory
    {
        public object Create(string message) => new { message = message };
        public object Create<T>(T data) => new { data = data };
        public object Create<T>(string message, T data) => new { message = message, data = data };
    }
}