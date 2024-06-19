using Shop.DAL.Common.RequestParams;
using Shop.DAL.Models;

namespace Shop.DAL.Interfaces;

public interface ICategoryRepository
{
    Task<IEnumerable<Category>> GetCategoriesAsync(CategoryParameters parameters,
        CancellationToken cancellationToken);
    Task<Category> GetCategoryByIdAsync(Guid id, CancellationToken cancellationToken);
    Task DeleteCategoryAsync(Guid id, CancellationToken cancellationToken);
    Task UpdateCategoryAsync(Guid id, Category Category, CancellationToken cancellationToken);
    Task<Guid> CreateCategoryAsync(Category Category, CancellationToken cancellationToken);
}