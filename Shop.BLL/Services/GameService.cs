using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Shop.BLL.Common.DataTransferObjects.Games;
using Shop.BLL.Exceptions.BadRequestExceptions;
using Shop.BLL.Exceptions.NotFoundExceptions;
using Shop.BLL.Exceptions.AlreadyExistsExceptions;
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

        public async Task DeleteGameAsync(Guid id, CancellationToken cancellationToken) 
        {
            var game = await _gameRepository.GetSingle(g => g.Id == id, cancellationToken);

            if (game is null)
            {
                _logger.LogError("Games not found exception in method DeleteGamesAsync in GameService");
                throw new NotFoundException($"Game with id:{id} not found ");
            }

            await _gameRepository.Delete(game, cancellationToken);
        }

        public async Task CreateGameAsync(GameRequestCreationDto gameRequestCreationDto, CancellationToken cancellationToken)
        {
            var game = _mapper.Map<Game>(gameRequestCreationDto);

            var existingGame = _gameRepository.GetSingle(exg => exg.Id == game.Id, cancellationToken);
            if (existingGame is not null)
            {
                _logger.LogError("Game already exists exception in method CreateGameAsync in GameService");
                throw new AlreadyExistsException("Game already exists");
            }

            await _gameRepository.Create(game,cancellationToken);
        }

        public async Task UpdateGameAsync(Guid id, GameRequestUpdateDto gameRequestUpdateDto, CancellationToken cancellationToken)
        {
            var game = await _gameRepository.GetSingle(g => g.Id == id, cancellationToken);
            if (game is null)
            {
                _logger.LogError("Game not found exception in method UpdateGamesAsync in GameService");
                throw new NotFoundException($"Game with id:{id} not found ");
            }
            _mapper.Map(gameRequestUpdateDto, game);
            await _gameRepository.Update(game, cancellationToken);
        }

        public async Task<IEnumerable<GameResponseDto>> GetGamesAsync(CancellationToken cancellationToken)
        {
            var games = await _gameRepository.GetRange(g=>true,cancellationToken);
            if(!games.Any())
            {
                _logger.LogError("Games not found exception in method GetGamesAsync in GameService");
                throw new NotFoundException("Any game not found");
            }
            var gamesDtos = _mapper.Map<IEnumerable<GameResponseDto>>(games);
            return gamesDtos;

        }

        public async Task<GameResponseDto> GetGameByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var game = await _gameRepository.GetSingle(g => g.Id==id, cancellationToken);

            if (game is null)
            {
                _logger.LogError("Game not found exception in method GetGameByIdAsync in GameService");
                throw new NotFoundException($"Game with id:{id} not found ");
                
            }
            var gameDto = _mapper.Map<GameResponseDto>(game);
            return gameDto;
        }

        public async Task<IEnumerable<GameResponseDto>> GetGamesByCategoryAsync(Guid id, CancellationToken cancellationToken)
        {
            var games = await _gameRepository.GetRange(g => g.Categories !=null && 
                g.Categories.Any(c => c.Id == id), cancellationToken);

            if(!games.Any())
            {
                _logger.LogError("Games not found exception in method GetGamesByCategoryAsync in GameService");
                throw new NotFoundException("Any game not found");
                
            }
            var gamesDtos = _mapper.Map<IEnumerable<GameResponseDto>>(games);
            return gamesDtos;

        }

        public async Task<IEnumerable<GameForOrderResponseDto>> GetGamesByOrderAsync(Guid id, CancellationToken cancellationToken)
        {
            var games = await _gameRepository.GetRange(g => g.OrderItems != null && 
                g.OrderItems.Any(oi => oi.Id == id), cancellationToken);

            if (!games.Any())
            {
                _logger.LogError("Games not found exception in method GetGamesByOrderAsync in GameService");
                throw new NotFoundException("Any game not found");
                
            }
            var gamesDtos = _mapper.Map<IEnumerable<GameForOrderResponseDto>>(games);
            return gamesDtos;

        }
    }
}
