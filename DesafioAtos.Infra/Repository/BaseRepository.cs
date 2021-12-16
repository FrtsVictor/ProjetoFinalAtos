using DesafioAtos.Domain.Entidades;
using DesafioAtos.Infra.Context;
using DesafioAtos.Infra.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

public class BaseRepository<T> : IBaseRepository<T> where T : EntidadeBase
{
    internal DatabaseContext _context;
    internal DbSet<T> dbSet;
    protected readonly ILogger _logger;

    protected BaseRepository(DatabaseContext context, ILogger logger)
    {
        _logger = logger;
        _context = context;
        this.dbSet = context.Set<T>();
    }

    public virtual async Task<T> CriarAsync(T entidade)
    {
        await dbSet.AddAsync(entidade);
        return entidade;
    }

    public virtual async Task<IEnumerable<T>> CriarVariosAsync(IEnumerable<T> entidades)
    {
        await dbSet.AddRangeAsync(entidades);
        return entidades;
    }

    public virtual bool Atualizar(T entidade)
    {
        dbSet.Update(entidade);
        return true;
    }

    public virtual async Task RemoverAsync(long id)
    {
        var usuarioParaDeletar = await ObterPorIdAsync(id);

        if (usuarioParaDeletar != null)
        {
            dbSet.Remove(usuarioParaDeletar);
        }
    }

    public virtual async Task<T?> ObterPorIdAsync(long id) => await dbSet
        .Where(x => x.Id == id).SingleOrDefaultAsync();

    public virtual async Task<IEnumerable<T>> ObterTodosAsync() => await dbSet
        .AsNoTracking().ToListAsync();
}