using Shop.DAL.Models;
using Shop.DAL.Interfaces;
using Shop.DAL.Contexts;

namespace Shop.DAL.Repositories
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(ShopContext shopContext) : base(shopContext)
        {
            
        }
    }
}