
using DesafioAtos.Domain.Entidades;

namespace DesafioAtos.Infra.Repository.Interfaces
{
    public interface ICategoriaEmpresaRepository : IBaseRepository<CategoriaEmpresa>
    {
        Task<CategoriaEmpresa?> ObterCategoriaPorId(int idCategoria, int idEmpresa);
        Task<List<Categoria>?> ObterTodasCategoriasPorEmpresa(int idEmpresaColetora);
        Task<List<CategoriaEmpresa>>? ObterEmpresasPorIdCategoria(IEnumerable<int> ids);
    }
}