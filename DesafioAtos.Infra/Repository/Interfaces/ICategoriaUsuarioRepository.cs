using DesafioAtos.Domain.Entidades;

namespace DesafioAtos.Infra.Repository.Interfaces
{
    public interface ICategoriaUsuarioRepository : IBaseRepository<CategoriaUsuario>
    {
        Task<CategoriaUsuario?> ObterCategoriaExistente(int idCategoria, int idUsuario);
        Task<List<string>> ObterTodosNomeCategoriaPorUsuario(int idUsuario);
    }
}