using DesafioAtos.Domain.Entidades;

namespace DesafioAtos.Infra.Repository.Interfaces
{
    public interface IBaseRepository<T> where T : EntidadeBase
    {
        Task<T> CriarAsync(T entity);
        void Atualizar(T entity);
        Task RemoverAsync(long id);
        Task<List<T>> ObterTodosAsync();
        Task<T> ObterPorIdAsync(long id);
    }
}