using Shop.BLL.Common.DataTransferObjects.Games;

namespace Shop.BLL.Interfaces{ 
    public interface IGameService{
        //TODO parameters and cancelation
        public Task<IEnumerable<GameDto>> GetGamesAsync(); 
        public Task<IEnumerable<GameDto>> GetGamesByCategoryAsync(Guid categoryId); 
        public Task<GameDto> GetGameByIdAsync(Guid gameId); 
        public Task CreateGameAsync(GameForCreationDto gameForCreationDto);
        public Task UpdateGameAsync(GameForUpdateDto gameForUpdateDto, Guid gameId); 
        public Task DeleteGameAsync(Guid gameId); 
    }
}