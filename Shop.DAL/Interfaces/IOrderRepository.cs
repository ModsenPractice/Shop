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
    void DeleteOrder(Guid id, CancellationToken cancellationToken);
    void UpdateOrder(Order order, CancellationToken cancellationToken);
    void CreateOrder(Order order, CancellationToken cancellationToken);
}