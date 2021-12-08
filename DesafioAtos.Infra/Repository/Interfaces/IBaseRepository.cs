using DesafioAtos.Domain.Entities;

namespace DesafioAtos.Infra.Repository.Interfaces
{
    public interface IBaseRepository<T> where T : Base
    {
        Task<T> Create(T entity);
        void Update(T entity);
        Task Remove(long id);
        Task<List<T>> Get();
        Task<T> GetById(long id);
    }
}