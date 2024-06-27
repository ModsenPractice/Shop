using Shop.BLL.Common.DataTransferObjects.Games;
using System.Threading;

namespace Shop.BLL.Interfaces{ 
    public interface IGameService{
        Task<IEnumerable<GameResponseDto>> GetGamesAsync(CancellationToken cancellation); 
        Task<IEnumerable<GameForOrderResponseDto>> GetGamesByOrderAsync(Guid id, CancellationToken cancellationToken); 
        Task<IEnumerable<GameResponseDto>> GetGamesByCategoryAsync(Guid id, CancellationToken cancellationToken); 
        Task<GameResponseDto> GetGameByIdAsync(Guid id, CancellationToken cancellationToken); 
        Task CreateGameAsync(GameRequestCreationDto gameRequestCreationDto);
        Task UpdateGameAsync(Guid id, GameRequestUpdateDto gameRequestUpdateDto, CancellationToken cancellationToken); 
        Task DeleteGameAsync(Guid id, CancellationToken cancellationToken); 
    }
}