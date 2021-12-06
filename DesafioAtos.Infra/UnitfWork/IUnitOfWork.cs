using DesafioAtos.Infra.Repository.Interfaces;

namespace DesafioAtos.Infra.UnitfWork
{
    public interface IUnitOfWork
    {
        ICustomerRepository Customers { get; }

        Task CompleteAsync();
    }
}