
using DesafioAtos.Domain.Entidades;

namespace DesafioAtos.Infra.Repository.Interfaces
{
    public interface ICategoriaEmpresaRepository : IBaseRepository<CategoriaEmpresa>
    {
        Task<CategoriaEmpresa?> ObterCategoriaPorId(int idCategoria, int idEmpresa);
        Task<IEnumerable<Categoria>?> ObterTodasCategoriasPorEmpresa(int idEmpresaColetora);
        Task<IEnumerable<CategoriaEmpresa>> ObterEmpresasPorIdCategoria(IEnumerable<int>? ids);
    }
}