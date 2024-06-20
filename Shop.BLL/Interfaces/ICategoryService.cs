using Shop.BLL.Common.DataTransferObjects.Categories;

namespace Shop.BLL.Interfaces{
    public interface ICategoryService{ 
        Task<IEnumerable<CategoryResponseDto>> GetCategoriesAsync(); 
        Task<CategoryResponseDto> GetCategoryByIdAsync(Guid id); 
        Task CreateCategoryAsync(CategoryRequestCreationDto dto);
        Task UpdateCategoryAsync(Guid id, CategoryRequestUpdateDto dto); 
        Task DeleteCategoryAsync(Guid id); 
    }
}