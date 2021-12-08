using DesafioAtos.Domain.Entities;
using DesafioAtos.Infra.Context;
using DesafioAtos.Infra.Exceptions;
using DesafioAtos.Infra.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

public class BaseRepository<T> : IBaseRepository<T> where T : Base
{
    private const string ErrorMessage = "Sorry we got an error ate repository layer check inner exception";
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
        await ExecuteWithErrorHandler(
            async () =>
            {
                return await dbSet.AddAsync(entity);
            });

        return entity;
    }

    public virtual void Update(T entity)
    {
        dbSet.Update(entity);
    }

    public virtual async Task Remove(long id)
    {
        await ExecuteWithErrorHandler(async () =>
        {
            var userToBeRemoved = await GetById(id);

            if (userToBeRemoved != null)
            {
                dbSet.Remove(userToBeRemoved);
            }

            return await _context.SaveChangesAsync();
        });
    }

    public virtual async Task<T> GetById(long id)
    {
        return await ExecuteWithErrorHandler<T>(
            async () => await dbSet.Where(x => x.Id == id).FirstOrDefaultAsync());
    }

    public virtual async Task<List<T>> Get()
    {
        return await ExecuteWithErrorHandler(
            async () => await dbSet.AsNoTracking().ToListAsync());
    }

    protected async Task<T> ExecuteWithErrorHandler<T>(Func<Task<T>> callback)
    {
        try
        {
            return await callback();
        }
        catch (Exception e)
        {
            throw new DatabaseException(ErrorMessage, e);
        }
    }
}