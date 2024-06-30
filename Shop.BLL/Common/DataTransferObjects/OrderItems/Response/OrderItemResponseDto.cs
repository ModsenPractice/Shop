using Shop.BLL.Common.DataTransferObjects.Games;

namespace Shop.BLL.Common.DataTransferObjects.OrderItems
{
   public record OrderItemResponseDto
   {
      public Guid Id { get; set; }
      public GameForOrderResponseDto Game { get; set; } = null!;
      public Guid OrderId { get; set; }
      public int Count { get; set; }
   }
}