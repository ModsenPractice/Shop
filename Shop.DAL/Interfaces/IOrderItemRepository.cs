using Shop.DAL.Common.RequestParams;
using Shop.DAL.Models;

namespace Shop.DAL.Interfaces
{
   public interface IOrderItemRepository
   {
      public Task<IEnumerable<Game>> GetOrderItemsByOrderIdAsync(OrderItemParameters parameters,
         CancellationToken cancellationToken);
      public Task<IEnumerable<Game>> GetOrderItemsByGameIdAsync(OrderItemParameters parameters,
         CancellationToken cancellationToken);

      public Task CreateOrderItemAsync(OrderItem orderItem, CancellationToken cancellationToken);
      public Task UpdateOrderItemAsync(Guid id, OrderItem orderItem,
         CancellationToken cancellationToken);
      public Task DeleteOrderItemAsync(Guid id, CancellationToken cancellationToken);
   }
}