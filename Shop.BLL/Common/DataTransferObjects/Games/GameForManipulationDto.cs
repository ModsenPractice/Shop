using Shop.BLL.Common.DataTransferObjects.Categories;

namespace Shop.BLL.Common.DataTransferObjects.Games
{
   public abstract record GameForManipulationDto
   {
      public string Name { get; set; } = null!;
      public string Description { get; set; } = null!;
      public string Developer { get; set; } = null!;
      public string Publisher { get; set; } = null!;
      public decimal Price { get; set; }
      public string ImageUrl { get; set; } = null!;
      public IEnumerable<CategoryDto> Categories { get; set; } = null!;
   }
}