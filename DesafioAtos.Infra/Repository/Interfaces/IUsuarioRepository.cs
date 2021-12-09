using DesafioAtos.Domain.Entidades;

namespace DesafioAtos.Infra.Repository.Interfaces
{
    public interface IUsuarioRepository : IBaseRepository<Usuario>
    {
        Task<Usuario> ObterPorLogin(string username);
    }
}

