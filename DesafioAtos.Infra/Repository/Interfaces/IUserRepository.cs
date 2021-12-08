using DesafioAtos.Domain.Entities;

namespace DesafioAtos.Infra.Repository.Interfaces
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User> GetByUsername(string username);
    }
}

