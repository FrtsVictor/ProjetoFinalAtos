using DesafioAtos.Domain.Entidades;
using DesafioAtos.Infra.Context;
using DesafioAtos.Infra.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DesafioAtos.Infra.Repository
{
    public class CategoriaUsuarioRepository : BaseRepository<CategoriaUsuario>, ICategoriaUsuarioRepository
    {
        public CategoriaUsuarioRepository(DatabaseContext context, ILogger logger) : base(context, logger) { }

        public async Task<CategoriaUsuario?> ObterCategoriaPorId(int idCategoria, int idUsuario) => await dbSet
            .Where(x => x.IdCategoria == idCategoria && x.IdUsuario == idUsuario)
            .FirstOrDefaultAsync();

        public async Task<List<Categoria>?> ObterTodasCategoriasPorUsuario(int idUsuario) => await dbSet
            .Where(x => x.IdUsuario == idUsuario)
            .Include(x => x.Categoria)
            .Select(x => x.Categoria)
            .ToListAsync();
    }
}