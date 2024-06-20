using Shop.BLL.Common.DataTransferObjects.OrderItems;

namespace Shop.BLL.Common.DataTransferObjects.Orders
{
   public record OrderRequestCreationDto : OrderRequestDto
   {
      public IEnumerable<OrderItemRequestCreationDto> OrderItems { get; set; } = null!;
   }
}