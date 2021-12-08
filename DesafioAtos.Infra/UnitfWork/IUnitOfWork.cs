using DesafioAtos.Infra.Repository.Interfaces;

namespace DesafioAtos.Infra.UnitfWork
{
    public interface IUnitOfWork
    {
        ICustomerRepository Customers { get; }
        IUserRepository Users { get; }
        IRoleRepository Roles { get; }
        Task CompleteAsync();
        Task<T> ExecuteChangesAsync<T>(Func<Task<T>> callback);
    }
}