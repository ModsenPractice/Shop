using Shop.DAL.Models;

namespace Shop.DAL.Interfaces; 

public interface ICategoryRepository{
    Task<IEnumerable<Category>> GetCategoriesAsync();
    Task<Category> GetCategoryByIdAsync(Guid id); 
    Task DeleteCategoryAsync(Guid id); 
    Task UpdateCategoryAsync(Guid id, Category Category); 
    Task<Guid> CreateCategoryAsync(Category Category);   
}