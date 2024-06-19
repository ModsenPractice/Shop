using Shop.BLL.Common.DataTransferObjects.Games;

namespace Shop.BLL.Common.DataTransferObjects.OrderItems
{
   public record OrderItemDto
   {
      public Guid Id { get; set; }
      public GameForOrderDto Game { get; set; } = null!;
      public int Count { get; set; }
   }
}