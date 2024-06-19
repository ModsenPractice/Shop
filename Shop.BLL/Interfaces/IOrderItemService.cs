using Shop.BLL.Common.DataTransferObjects.OrderItems;

namespace Shop.BLL.Interfaces;

public interface IOrderItemService{ 
    //TODO parameters and cancelation
    public Task<IEnumerable<OrderItemDto>> GetOrderItemsByOrderIdAsync(Guid orderId); 
    public Task<IEnumerable<OrderItemDto>> GetOrderItemsByGameIdAsync(Guid gameId); 
}
