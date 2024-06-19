using Shop.BLL.Common.DataTransferObjects.Orders;

namespace Shop.BLL.Interfaces{ 
    public interface IOrderService{
        //TODO parameters and cancelation
        public Task<IEnumerable<OrderDto>> GetOrdersAsync(); 
        public Task<IEnumerable<OrderDto>> GetOrdersByUserIdAsync(Guid userId); 
        public Task<OrderDto> GetOrderByIdAsync(Guid orderId); 
        public Task CreateOrderAsync(OrderForCreationDto orderForCreationDto);
    }
}