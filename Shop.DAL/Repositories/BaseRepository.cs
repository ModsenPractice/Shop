using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Shop.DAL.Contexts;
using Shop.DAL.Interfaces;

namespace Shop.DAL.Repositories;

public class BaseRepository<T> : IBaseRepository<T> where T : class
{
    protected readonly ShopContext _context;

    public BaseRepository(ShopContext context)
    {
        _context = context; 
    }

    public void Create(T entity)
    {
        _context.Set<T>().Add(entity); 
    }

    public void Delete(T entity)
    {
        _context.Set<T>().Remove(entity);
    }

    public async Task<IEnumerable<T>> GetRange(Expression<Func<T, bool>> condition, CancellationToken cancellationToken)
    {
        return await _context.Set<T>().Where(condition).ToListAsync();
    }

    public async Task<T?> GetSingle(Expression<Func<T, bool>> condition, CancellationToken cancellationToken)
    {
        return await _context.Set<T>().Where(condition).SingleOrDefaultAsync();
    }

    public void Update(T entity)
    {
        _context.Set<T>().Update(entity);
    }
}