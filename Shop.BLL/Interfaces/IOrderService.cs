using Shop.BLL.Common.DataTransferObjects.Orders;

namespace Shop.BLL.Interfaces{ 
    public interface IOrderService{
        Task<IEnumerable<OrderResponseDto>> GetOrdersAsync(); 
        Task<IEnumerable<OrderResponseDto>> GetOrdersByUserIdAsync(Guid id); 
        Task<OrderResponseDto> GetOrderByIdAsync(Guid id); 
        Task CreateOrderAsync(OrderRequestCreationDto dto);
    }
}