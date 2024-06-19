namespace Shop.BLL.Common.DataTransferObjects.Orders
{
   public abstract record OrderForManipulationDto
   {
      public Guid UserId { get; set; }
      public decimal TotalPrice { get; set; }
   }
}