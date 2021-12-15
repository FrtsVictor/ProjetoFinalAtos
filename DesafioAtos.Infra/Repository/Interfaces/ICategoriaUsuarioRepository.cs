using DesafioAtos.Domain.Entidades;

namespace DesafioAtos.Infra.Repository.Interfaces
{
    public interface ICategoriaUsuarioRepository : IBaseRepository<CategoriaUsuario>
    {
        Task<CategoriaUsuario?> ObterCategoriaPorId(int idCategoria, int idUsuario);
        Task<List<Categoria>?> ObterTodasCategoriasPorUsuario(int idUsuario);
    }
}