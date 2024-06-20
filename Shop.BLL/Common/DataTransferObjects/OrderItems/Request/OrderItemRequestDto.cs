using Shop.BLL.Common.DataTransferObjects.Games;

namespace Shop.BLL.Common.DataTransferObjects.OrderItems
{
   public abstract record OrderItemRequestDto
   {
      public Guid GameId { get; set; }
      public int Count { get; set; }
   }
}