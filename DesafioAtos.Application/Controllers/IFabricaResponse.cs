namespace DesafioAtos.Application.Controllers
{
    public interface IFabricaResponse
    {
        object Criar(string message);
        object Criar<T>(T obj);
        object Criar<T>(string message, T obj);
    }
}