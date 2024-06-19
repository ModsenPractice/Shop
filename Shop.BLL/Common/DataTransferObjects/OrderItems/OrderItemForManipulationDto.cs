using Shop.BLL.Common.DataTransferObjects.Games;

namespace Shop.BLL.Common.DataTransferObjects.OrderItems
{
   public abstract record OrderItemForManipulationDto
   {
      public Guid GameId { get; set; }
      public int Count { get; set; }
   }
}