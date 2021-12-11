namespace DesafioAtos.Application.Controllers
{
    public interface IFabricaResponse
    {
        object Create(string message);
        object Create<T>(T obj);
        object Create<T>(string message, T obj);
    }
}