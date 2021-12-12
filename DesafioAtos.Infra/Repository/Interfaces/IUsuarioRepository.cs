using DesafioAtos.Domain.Entidades;

namespace DesafioAtos.Infra.Repository.Interfaces
{
    public interface IUsuarioRepository : IBaseRepository<Usuario>
    {
        Task<Usuario?> ObterPorLoginAsync(string username);
    }
}

