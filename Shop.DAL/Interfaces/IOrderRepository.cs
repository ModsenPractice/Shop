using Shop.DAL.Models;

namespace Shop.DAL.Interfaces; 

public interface IOrderRepository{ 
    Task<IEnumerable<Order>> GetOrdersAsync();
    Task<IEnumerable<Order>> GetOrdersByUserIdAsync(Guid userId);
    Task<Order> GetOrderByIdAsync(Guid id); 
    Task DeleteOrderAsync(Guid id); 
    Task UpdateOrderAsync(Guid id, Order order); 
    Task<Guid> CreateOrderAsync(Order order);   
}