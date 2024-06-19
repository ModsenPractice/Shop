namespace Shop.BLL.Common.DataTransferObjects.Categories
{
   public abstract record CategoryForManipulationDto
   {
      public string Name { get; set; } = null!;
   }
}