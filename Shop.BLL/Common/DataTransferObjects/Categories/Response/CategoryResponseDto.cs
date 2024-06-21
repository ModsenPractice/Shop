namespace Shop.BLL.Common.DataTransferObjects.Categories
{
   public record CategoryResponseDto
   {
      public Guid Id { get; set; }
      public string Name { get; set; } = null!;
   }
}