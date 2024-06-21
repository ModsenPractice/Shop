using Shop.BLL.Common.DataTransferObjects.Games;

namespace Shop.BLL.Interfaces{ 
    public interface IGameService{
        Task<IEnumerable<GameResponseDto>> GetGamesAsync(); 
        Task<IEnumerable<GameForOrderResponseDto>> GetGamesByOrderAsync(Guid id); 
        Task<IEnumerable<GameResponseDto>> GetGamesByCategoryAsync(Guid id); 
        Task<GameResponseDto> GetGameByIdAsync(Guid id); 
        Task CreateGameAsync(GameRequestCreationDto gameRequestCreationDto);
        Task UpdateGameAsync(Guid id, GameRequestUpdateDto gameRequestUpdateDto); 
        Task DeleteGameAsync(Guid id); 
    }
}