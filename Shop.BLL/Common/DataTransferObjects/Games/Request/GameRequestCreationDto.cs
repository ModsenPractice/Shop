using Shop.BLL.Common.DataTransferObjects.Categories;

namespace Shop.BLL.Common.DataTransferObjects.Games
{
   public record GameRequestCreationDto : GameRequestDto
   {
      public IEnumerable<CategoryRequestCreationDto> Categories { get; set; } = null!;
   }
}