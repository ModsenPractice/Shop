using Shop.DAL.Interfaces;
using Shop.DAL.Models;
using Shop.DAL.Contexts;

namespace Shop.DAL.Repositories
{
    public class GameRepository : BaseRepository<Game>, IGameRepository
    {
        public GameRepository(ShopContext repositoryContext)
            : base(repositoryContext)
        {
        }

    }
}
