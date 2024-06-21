using System.Linq.Expressions;

namespace Shop.DAL.Interfaces
{
   public interface IBaseRepository<T>
   {
      //Get single entity by condition. Throws exception if more that 1 entity exists
      public Task<T?> GetSingle(Expression<Func<T, bool>> condition,
         CancellationToken cancellationToken);
      public Task<IEnumerable<T>> GetRange(Expression<Func<T, bool>> condition,
         CancellationToken cancellationToken);
      public void Create(T entity);
      public void Update(T entity);
      public void Delete(T entity);
   }
}