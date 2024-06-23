using Shop.BLL.Common.DataTransferObjects.Categories;

namespace Shop.BLL.Common.DataTransferObjects.Games
{
   public record GameRequestUpdateDto : GameRequestDto
   {
      public IEnumerable<CategoryRequestUpdateDto> Categories { get; set; } = null!;
   }
}