using DesafioAtos.Domain.Entities;
using DesafioAtos.Infra.Context;
using DesafioAtos.Infra.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

public class BaseRepository<T> : IBaseRepository<T> where T : Base
{
    protected DatabaseContext _context;
    protected DbSet<T> dbSet;
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
        await _context.SaveChangesAsync();
        return entity;
    }

    public virtual async Task Update(T entity)
    {
        dbSet.Update(entity);
        await _context.SaveChangesAsync();
    }

    public virtual async Task Remove(long id)
    {
        var userToBeRemoved = await GetById(id);

        if (userToBeRemoved != null)
        {
            dbSet.Remove(userToBeRemoved);
        }

        await _context.SaveChangesAsync();
    }

    public virtual async Task<T> GetById(long id)
    {
        var entity = await dbSet
                                 .AsNoTracking()
                                 .Where(x => x.Id == id)
                                 .ToListAsync();

        return entity.FirstOrDefault();
    }

    public virtual async Task<List<T>> Get()
    {
        return await dbSet.AsNoTracking().ToListAsync();
    }
}