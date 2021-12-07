using DesafioAtos.Infra.Repository.Interfaces;

namespace DesafioAtos.Infra.UnitfWork
{
    public interface IUnitOfWork
    {
        ICustomerRepository Customers { get; }
        IUserRepository Users { get; }

        Task CompleteAsync();

        Task<T> ExecuteAsync<T>(Func<Task<T>> callback);
    }
}