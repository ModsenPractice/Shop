using Shop.BLL.Common.DataTransferObjects.Orders;

namespace Shop.BLL.Interfaces{ 
    public interface IOrderService{
        Task<IEnumerable<OrderResponseDto>> GetOrdersAsync(CancellationToken cancellation); 
        Task<IEnumerable<OrderResponseDto>> GetOrdersByUserIdAsync(Guid userId, CancellationToken cancellation); 
        Task<OrderResponseDto> GetOrderByIdAsync(Guid id, CancellationToken cancellation); 
        Task CreateOrderAsync(OrderRequestCreationDto orderRequestCreationDto, CancellationToken cancellation);
    }
}