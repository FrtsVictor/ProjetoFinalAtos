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

    public virtual void Atualizar(T entidade)
    {
        dbSet.Update(entidade);
    }

    public virtual async Task RemoverAsync(long id)
    {
        var usuarioParaDeletar = await ObterPorIdAsync(id);

        if (usuarioParaDeletar != null)
        {
            dbSet.Remove(usuarioParaDeletar);
        }
    }

    public virtual async Task<T> ObterPorIdAsync(long id)
    {
        return await dbSet.Where(x => x.Id == id).FirstOrDefaultAsync();
    }

    public virtual async Task<List<T>> ObterTodosAsync()
    {
        return await dbSet.AsNoTracking().ToListAsync();
    }
}