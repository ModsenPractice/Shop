using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Shop.BLL.Common.DataTransferObjects.Games;
using Shop.BLL.Exceptions.BadRequestExceptions;
using Shop.BLL.Exceptions.NotFoundExceptions;
using Shop.BLL.Interfaces;
using Shop.DAL.Models;
using Shop.DAL.Interfaces;
using System.Threading.Tasks;


namespace Shop.BLL.Services
{
    public class GameService : IGameService
    {
        private readonly ILogger<GameService> _logger;
        private readonly IMapper _mapper;
        private readonly IGameRepository _gameRepository;
        private readonly IUnitOfWork _unitOfWork;

        public GameService(ILogger<GameService> logger, IMapper mapper, IGameRepository gameRepository, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _mapper = mapper;
            _gameRepository = gameRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task DeleteGameAsync(Guid id) 
        {
            var game = await _gameRepository.GetSingle(g => g.Id == id, CancellationToken.None);

            if (game is not null)
            {
                _gameRepository.Delete(game);
                await _unitOfWork.SaveChangesAsync();
            }
        }

        public async Task CreateGameAsync(GameRequestCreationDto gameRequestCreationDto)
        {
            var game = _mapper.Map<Game>(gameRequestCreationDto);

            _gameRepository.Create(game);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateGameAsync(Guid id, GameRequestUpdateDto gameRequestUpdateDto)
        {
            var game = await _gameRepository.GetSingle(g => g.Id == id, CancellationToken.None)
                ?? throw new GameNotFoundException(id);

            _mapper.Map(gameRequestUpdateDto, game);
            _gameRepository.Update(game);
            
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<IEnumerable<GameResponseDto>> GetGamesAsync()
        {
            var games = await _gameRepository.GetRange(g=>true,CancellationToken.None);
            if(games.Any())
            {
                var gamesDtos = _mapper.Map<IEnumerable<GameResponseDto>>(games);
                return gamesDtos;
            }
            else
            {
                _logger.LogError("Games not found exception in method GetGamesAsync in GameService");
                throw new GameNotFoundException();
            }
           
        }

        public async Task<GameResponseDto> GetGameByIdAsync(Guid id)
        {
            var game = await _gameRepository.GetSingle(g => g.Id==id, CancellationToken.None);

            if (game is not null)
            {
                var gameDto = _mapper.Map<GameResponseDto>(game);
                return gameDto;
            }
            else
            {
                _logger.LogError("Game not found exception in method GetGameByIdAsync in GameService");
                throw new GameNotFoundException(id);
            }
        }

        public async Task<IEnumerable<GameResponseDto>> GetGamesByCategoryAsync(Guid id)
        {
            var games = await _gameRepository.GetRange(g => g.Categories !=null && 
                g.Categories.Any(c => c.Id == id), CancellationToken.None);

            if(games.Any())
            {
                var gamesDtos = _mapper.Map<IEnumerable<GameResponseDto>>(games);
                return gamesDtos;
            }
            else
            {
                _logger.LogError("Games not found exception in method GetGamesByCategoryAsync in GameService");
                throw new GameNotFoundException();
            }
            
        }

        public async Task<IEnumerable<GameForOrderResponseDto>> GetGamesByOrderAsync(Guid id)
        {
            var games = await _gameRepository.GetRange(g => g.OrderItems != null && 
                g.OrderItems.Any(oi => oi.Id == id), CancellationToken.None);

            if (games.Any())
            {
                var gamesDtos = _mapper.Map<IEnumerable<GameForOrderResponseDto>>(games);

                return gamesDtos;
            }
            else
            {
                _logger.LogError("Games not found exception in method GetGamesByOrderAsync in GameService");
                throw new GameNotFoundException();
            }

        }
    }
}
