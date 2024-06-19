using Shop.BLL.Common.DataTransferObjects.Categories;

namespace Shop.BLL.Interfaces{
    public interface ICategoryService{ 
        //TODO parameters and cancelation
        public Task<IEnumerable<CategoryDto>> GetCategoriesAsync(); 
        public Task<CategoryDto> GetCategoryByIdAsync(Guid categoryId); 
        public Task CreateCategoryAsync(CategoryForCreationDto categoryForCreationDto);
        public Task UpdateCategoryAsync(CategoryForUpdateDto categoryForUpdateDto, Guid categoryId); 
        public Task DeleteCategoryAsync(Guid categoryId); 
    }
}