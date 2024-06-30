using Shop.BLL.Common.DataTransferObjects.OrderItems;

namespace Shop.BLL.Interfaces;

public interface IOrderItemService
{
    Task<IEnumerable<OrderItemResponseDto>> GetOrderItemsByOrderIdAsync(Guid id,
        CancellationToken cancellationToken);
    Task<IEnumerable<OrderItemResponseDto>> GetOrderItemsByGameIdAsync(Guid id,
        CancellationToken cancellationToken);
}
