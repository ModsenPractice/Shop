namespace Shop.BLL.Common.DataTransferObjects.Categories
{
   public record CategoryDto
   {
      public Guid Id { get; set; }
      public string Name { get; set; } = null!;
   }
}