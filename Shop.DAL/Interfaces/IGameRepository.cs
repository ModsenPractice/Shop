using Shop.DAL.Models;

namespace Shop.DAL.Interfaces; 

public interface IGameRepository{ 
    Task<IEnumerable<Game>> GetGamesAsync();
    Task<Game> GetGameByIdAsync(Guid id); 
    Task<IEnumerable<Game>> GetGamesByCategoryAsync(Category category);
    Task DeleteGameAsync(Guid id); 
    Task UpdateGameAsync(Guid id, Game game); 
    Task<Guid> CreateGameAsync(Game game);    
}