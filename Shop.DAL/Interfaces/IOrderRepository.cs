using Shop.DAL.Common.RequestParams;
using Shop.DAL.Models;

namespace Shop.DAL.Interfaces;

public interface IOrderRepository
{
    Task<IEnumerable<Order>> GetOrdersAsync(OrderParameters parameters,
        CancellationToken cancellationToken);
    Task<IEnumerable<Order>> GetOrdersByUserIdAsync(Guid userId, OrderParameters parameters,
        CancellationToken cancellationToken);
    Task<Order> GetOrderByIdAsync(Guid id, CancellationToken cancellationToken);
    Task DeleteOrderAsync(Guid id, CancellationToken cancellationToken);
    Task UpdateOrderAsync(Guid id, Order order, CancellationToken cancellationToken);
    Task<Guid> CreateOrderAsync(Order order, CancellationToken cancellationToken);
}