using System.Linq.Expressions;

namespace Shop.DAL.Interfaces
{
   public interface IBaseRepository<T>
   {
      public Task<T?> GetSingle(Expression<Func<T, bool>> condition,
         CancellationToken cancellationToken);
      public Task<IEnumerable<T>> GetRange(Expression<Func<T, bool>> condition,
         CancellationToken cancellationToken);
      public Task Create(T entity, CancellationToken cancellationToken);
      public Task Update(T entity, CancellationToken cancellationToken);
      public Task Delete(T entity, CancellationToken cancellationToken);
   }
}