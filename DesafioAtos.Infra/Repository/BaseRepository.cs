using DesafioAtos.Domain.Entities;
using DesafioAtos.Infra.Context;
using DesafioAtos.Infra.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

public class BaseRepository<T> : IBaseRepository<T> where T : Base
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

    public virtual async Task<T> Create(T entity)
    {
        await dbSet.AddAsync(entity);
        return entity;
    }

    public virtual void Update(T entity)
    {
        dbSet.Update(entity);
    }

    public virtual async Task Remove(long id)
    {
        var userToBeRemoved = await GetById(id);

        if (userToBeRemoved != null)
        {
            dbSet.Remove(userToBeRemoved);
        }
    }

    public virtual async Task<T> GetById(long id)
    {
        return await dbSet.Where(x => x.Id == id).FirstOrDefaultAsync();
    }

    public virtual async Task<List<T>> Get()
    {
        return await dbSet.AsNoTracking().ToListAsync();
    }
}