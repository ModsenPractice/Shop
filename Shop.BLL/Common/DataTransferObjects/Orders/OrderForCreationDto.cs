using Shop.BLL.Common.DataTransferObjects.OrderItems;

namespace Shop.BLL.Common.DataTransferObjects.Orders
{
   public record OrderForCreationDto : OrderForManipulationDto
   {
      public IEnumerable<OrderItemForCreationDto> OrderItems { get; set; } = null!;
   }
}