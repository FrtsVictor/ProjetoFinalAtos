namespace DesafioAtos.Application.Controllers
{
    public interface IResponseFactory
    {
        object Create(string message);
        object Create<T>(T obj);
        object Create<T>(string message, T obj);
    }
}