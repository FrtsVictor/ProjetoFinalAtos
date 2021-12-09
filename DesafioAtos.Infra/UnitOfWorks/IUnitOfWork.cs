using DesafioAtos.Infra.Repository.Interfaces;

namespace DesafioAtos.Infra.UnitOfWorks
{
    public interface IUnitOfWork
    {
        IUsuarioRepository Users { get; }
        Task SalvarAsync();
        Task<T> ExecutarAsync<T>(Func<Task<T>> callback);
        Task VoidExecutarAsync<T>(Func<Task<T>> callback);
    }
}