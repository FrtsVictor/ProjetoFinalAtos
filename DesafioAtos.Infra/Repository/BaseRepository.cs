using System.Collections.Generic;
using System.Threading.Tasks;

public class BaseRepository<T> : IBaseRepository<T> where T : Base
{
    public virtual async Task<T> Create(T obj) => obj;

    public virtual async Task<T> Update(T obj) => obj;

    public virtual async Task<T> Remove(long id) => null;

    public virtual async Task<T> Get(long id) => null;

    public virtual async Task<List<T>> Get() => null;
}