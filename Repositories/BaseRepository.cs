using api.Models.DB;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories;

public class BaseRepository<T> : IRepository<T> where T : BaseModel
{
    protected readonly DbContext Context;

    public BaseRepository(DbContext context)
    {
        Context = context;
    }

    public async Task<T?> Get(Ulid id)
    {
        return await Context.Set<T>().FindAsync(id);
    }

    public async Task<IEnumerable<T>> GetMany(Func<T, bool> predicate, ICriteria criteria)
    {
        return await Task.FromResult(
            Context
                .Set<T>()
                .Where(predicate)
                .Skip(criteria.Page * criteria.Pagination)
                .Take(criteria.Pagination)
                .ToList()
            );
    }

    public async Task<IEnumerable<T>> GetMany(Func<T, bool> predicate)
    {
        return await Task.FromResult(Context.Set<T>().Where(predicate).ToList());
    }

    public async Task Add(T entity)
    {
        await Context.Set<T>().AddAsync(entity);
    }

    public async Task Delete(T entity)
    {
        await Task.FromResult(Context.Set<T>().Remove(entity));
    }

    public async Task<int> Count()
    {
        return await Context.Set<T>().CountAsync();
    }
}