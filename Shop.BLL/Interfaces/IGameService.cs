using Shop.BLL.Common.DataTransferObjects.Games;

namespace Shop.BLL.Interfaces{ 
    public interface IGameService{
        Task<IEnumerable<GameResponseDto>> GetGamesAsync(); 
        Task<IEnumerable<GameForOrderResponseDto>> GetGamesByOrderAsync(Guid id); 
        Task<IEnumerable<GameResponseDto>> GetGamesByCategoryAsync(Guid id); 
        Task<GameResponseDto> GetGameByIdAsync(Guid id); 
        Task CreateGameAsync(GameRequestCreationDto dto);
        Task UpdateGameAsync(Guid id, GameRequestUpdateDto dto); 
        Task DeleteGameAsync(Guid id); 
    }
}