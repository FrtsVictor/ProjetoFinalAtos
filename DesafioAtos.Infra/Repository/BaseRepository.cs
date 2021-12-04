using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

public class BaseRepository<T> : IBaseRepository<T> where T : Base
{
    private readonly DatabaseContext _context;

    public BaseRepository(DatabaseContext context)
    {
        _context = context;
    }

    public virtual async Task<T> Create(T entity)
    {
        _context.Set<T>().Add(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public virtual async Task Update(T entity)
    {
        _context.Set<T>().Update(entity);
        await _context.SaveChangesAsync();
    }

    public virtual async Task Remove(long id)
    {
        var userToBeRemoved = await GetById(id);

        if (userToBeRemoved != null)
        {
            _context.Set<T>().Remove(userToBeRemoved);
        }

        await _context.SaveChangesAsync();
    }

    public virtual async Task<T> GetById(long id)
    {
        var entity = await _context.Set<T>()
                                 .AsNoTracking()
                                 .Where(x => x.Id == id)
                                 .ToListAsync();

        return entity.FirstOrDefault();
    }

    public virtual async Task<List<T>> Get()
    {
        return await _context.Set<T>().AsNoTracking().ToListAsync();
    }
}