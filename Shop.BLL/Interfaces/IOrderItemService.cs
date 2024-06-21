using Shop.BLL.Common.DataTransferObjects.OrderItems;

namespace Shop.BLL.Interfaces;

public interface IOrderItemService{ 
    Task<IEnumerable<OrderItemResponseDto>> GetOrderItemsByOrderIdAsync(Guid id); 
    Task<IEnumerable<OrderItemResponseDto>> GetOrderItemsByGameIdAsync(Guid id); 
}
