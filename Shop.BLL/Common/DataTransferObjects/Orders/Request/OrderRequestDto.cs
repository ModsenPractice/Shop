namespace Shop.BLL.Common.DataTransferObjects.Orders
{
   public abstract record OrderRequestDto
   {
      public Guid UserId { get; set; }
   }
}