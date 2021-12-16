using DesafioAtos.Domain.Entidades;
using DesafioAtos.Infra.Context;
using DesafioAtos.Infra.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DesafioAtos.Infra.Repository
{
    public class CategoriaEmpresaRepository : BaseRepository<CategoriaEmpresa>, ICategoriaEmpresaRepository
    {
        public CategoriaEmpresaRepository(DatabaseContext context, ILogger logger) : base(context, logger) { }

        public async Task<CategoriaEmpresa?> ObterCategoriaPorId(int idCategoria, int idEmpresa) => await dbSet
            .Where(x => x.IdCategoria == idCategoria && x.IdEmpresaColetora == idEmpresa)
            .FirstOrDefaultAsync();

        public async Task<IEnumerable<Categoria>?> ObterTodasCategoriasPorEmpresa(int idEmpresaColetora) => await dbSet
                .Where(x => x.IdEmpresaColetora == idEmpresaColetora)
                .Include(x => x.Categoria)
                .Select(x => x.Categoria)
                .ToListAsync();

        public async Task<IEnumerable<CategoriaEmpresa>>? ObterEmpresasPorIdCategoria(IEnumerable<int> ids) => await dbSet
            .Where(x => ids.Contains(x.IdCategoria))
            .Include(x => x.EmpresaColetora)
            .ThenInclude(x => x.Enderecos)
            .ToListAsync();        
    }
}