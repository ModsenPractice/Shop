namespace Shop.BLL.Common.DataTransferObjects.Categories
{
   public abstract record CategoryRequestDto
   {
      public string Name { get; set; } = null!;
   }
}