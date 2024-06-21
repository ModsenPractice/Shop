using Shop.BLL.Common.DataTransferObjects.Categories;

namespace Shop.BLL.Interfaces{
    public interface ICategoryService{ 
        Task<IEnumerable<CategoryResponseDto>> GetCategoriesAsync(); 
        Task<CategoryResponseDto> GetCategoryByIdAsync(Guid id); 
        Task CreateCategoryAsync(CategoryRequestCreationDto categoryRequestCreationDto);
        Task UpdateCategoryAsync(Guid id, CategoryRequestUpdateDto categoryRequestUpdateDto); 
        Task DeleteCategoryAsync(Guid id); 
    }
}