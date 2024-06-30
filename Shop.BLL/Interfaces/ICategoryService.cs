using Shop.BLL.Common.DataTransferObjects.Categories;

namespace Shop.BLL.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryResponseDto>> GetCategoriesAsync(CancellationToken cancellationToken);
        Task<CategoryResponseDto> GetCategoryByIdAsync(Guid id, CancellationToken cancellationToken);
        Task<CategoryResponseDto> CreateCategoryAsync(CategoryRequestCreationDto categoryRequestCreationDto,
            CancellationToken cancellationToken);
        Task UpdateCategoryAsync(Guid id, CategoryRequestUpdateDto categoryRequestUpdateDto,
            CancellationToken cancellationToken);
        Task DeleteCategoryAsync(Guid id, CancellationToken cancellationToken);
    }
}