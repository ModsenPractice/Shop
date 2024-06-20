using Shop.DAL.Common.RequestParams;
using Shop.DAL.Models;

namespace Shop.DAL.Interfaces
{
   public interface IOrderItemRepository
   {
      Task<IEnumerable<Game>> GetOrderItemsByOrderIdAsync(OrderItemParameters parameters,
         CancellationToken cancellationToken);
      Task<IEnumerable<Game>> GetOrderItemsByGameIdAsync(OrderItemParameters parameters,
         CancellationToken cancellationToken);

      void UpdateOrderItem(OrderItem orderItem, CancellationToken cancellationToken);
      void DeleteOrderItem(Guid id, CancellationToken cancellationToken);
      void CreateOrderItem(OrderItem orderItem, CancellationToken cancellationToken);
   }
}