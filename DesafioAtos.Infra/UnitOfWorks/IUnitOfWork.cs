using DesafioAtos.Infra.Repository.Interfaces;

namespace DesafioAtos.Infra.UnitOfWorks
{
    public interface IUnitOfWork
    {
        ICustomerRepository Customers { get; }
        IUserRepository Users { get; }
        IRoleRepository Roles { get; }
        Task CompleteAsync();
        Task<T> ExecuteAsync<T>(Func<Task<T>> callback);
        Task VoidExecuteAsync<T>(Func<Task<T>> callback);
    }
}