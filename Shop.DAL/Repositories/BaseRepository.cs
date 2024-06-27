using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Shop.DAL.Contexts;
using Shop.DAL.Interfaces;

namespace Shop.DAL.Repositories;

public abstract class BaseRepository<T> : IBaseRepository<T> where T : class
{
    protected readonly ShopContext _context;

    public BaseRepository(ShopContext context)
    {
        _context = context;
    }

    public async Task Create(T entity, CancellationToken cancellationToken)
    {
        _context.Set<T>().Add(entity);    
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task Delete(T entity, CancellationToken cancellationToken)
    {
        _context.Set<T>().Remove(entity);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<IEnumerable<T>> GetRange(Expression<Func<T, bool>> condition,
        CancellationToken cancellationToken)
    {
        return await _context.Set<T>().Where(condition)
            .AsNoTracking()
            .ToListAsync(cancellationToken);
    }

    public async Task<T?> GetSingle(Expression<Func<T, bool>> condition,
        CancellationToken cancellationToken)
    {
        return await _context.Set<T>().Where(condition)
            .AsNoTracking()
            .FirstOrDefaultAsync(cancellationToken);
    }

    public async Task Update(T entity, CancellationToken cancellationToken)
    {
        _context.Set<T>().Update(entity);
        await _context.SaveChangesAsync(cancellationToken);
    }
}