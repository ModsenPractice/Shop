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
    void DeleteGame(Guid id, CancellationToken cancellationToken);
    void UpdateGame(Game game, CancellationToken cancellationToken);
    void CreateGame(Game game, CancellationToken cancellationToken);
}