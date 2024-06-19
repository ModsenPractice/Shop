using Shop.BLL.Common.DataTransferObjects.OrderItems;

namespace Shop.BLL.Common.DataTransferObjects.Orders
{
   public record OrderDto
   {
      public Guid Id { get; set; }
      public Guid UserId { get; set; }
      public IEnumerable<OrderItemDto> OrderItems { get; set; } = null!;
      public decimal TotalPrice { get; set; }
   }
}