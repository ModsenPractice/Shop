namespace Shop.BLL.Common.DataTransferObjects.Games
{
   public record GameForOrderDto
   {
      public Guid Id { get; set; }
      public string Name { get; set; } = null!;
      public decimal Price { get; set; }
      public string ImageUrl { get; set; } = null!;
   }
}