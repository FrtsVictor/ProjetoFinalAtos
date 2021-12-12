namespace DesafioAtos.Service.Fabrica.Services
{
    public interface IService 
    {
        T GetInstance<T>() where T : new();
    }
}