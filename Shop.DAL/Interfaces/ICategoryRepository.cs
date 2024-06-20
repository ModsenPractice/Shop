using Shop.DAL.Common.RequestParams;
using Shop.DAL.Models;

namespace Shop.DAL.Interfaces;

public interface ICategoryRepository
{
    Task<IEnumerable<Category>> GetCategoriesAsync(CategoryParameters parameters,
        CancellationToken cancellationToken);
    Task<Category> GetCategoryByIdAsync(Guid id, CancellationToken cancellationToken);
    void DeleteCategory(Guid id, CancellationToken cancellationToken);
    void UpdateCategory(Category Category, CancellationToken cancellationToken);
    void CreateCategory(Category Category, CancellationToken cancellationToken);
}