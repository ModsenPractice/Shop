using Shop.DAL.Common.RequestParams;
using Shop.DAL.Models;

namespace Shop.DAL.Interfaces;

public interface IGameRepository
{
    Task<IEnumerable<Game>> GetGamesAsync(GameParameters parameters,
        CancellationToken cancellationToken);
    Task<Game> GetGameByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<IEnumerable<Game>> GetGamesByCategoryAsync(Category category, GameParameters parameters,
        CancellationToken cancellationToken);
    Task DeleteGameAsync(Guid id, CancellationToken cancellationToken);
    Task UpdateGameAsync(Guid id, Game game, CancellationToken cancellationToken);
    Task<Guid> CreateGameAsync(Game game, CancellationToken cancellationToken);
}