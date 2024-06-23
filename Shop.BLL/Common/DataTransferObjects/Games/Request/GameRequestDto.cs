using Shop.BLL.Common.DataTransferObjects.Categories;

namespace Shop.BLL.Common.DataTransferObjects.Games
{
   public abstract record GameRequestDto
   {
      public string Name { get; set; } = null!;
      public string Description { get; set; } = null!;
      public string Developer { get; set; } = null!;
      public string Publisher { get; set; } = null!;
      public decimal Price { get; set; }
      //May be change to IFormFile
      public string ImageUrl { get; set; } = null!;

      //May be guid collection of categories should be added
   }
}