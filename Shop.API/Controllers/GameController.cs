using Microsoft.AspNetCore.Mvc;
using Shop.BLL.Common.DataTransferObjects.Games;
using Shop.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Shop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly IGameService _gameService;

        public GameController(IGameService gameService)
        {
            _gameService = gameService;
        }

        [HttpGet]
        public async Task<IEnumerable<GameResponseDto>> GetGames(CancellationToken cancellationToken)
        {
            return await _gameService.GetGamesAsync(cancellationToken);
        }

        [HttpGet("{id:guid}")]
        public async Task<GameResponseDto> GetGameById(Guid id, CancellationToken cancellationToken)
        {
            return await _gameService.GetGameByIdAsync(id, cancellationToken);
        }

        [HttpGet("category/{id:guid}")]
        public async Task<IEnumerable<GameResponseDto>> GetGamesByCategory(Guid id, CancellationToken cancellationToken)
        {
            return await _gameService.GetGamesByCategoryAsync(id, cancellationToken);
        }

        [HttpGet("order/{id:guid}")]
        public async Task<IEnumerable<GameForOrderResponseDto>> GetGamesByOrder(Guid id, CancellationToken cancellationToken)
        {
            return await _gameService.GetGamesByOrderAsync(id, cancellationToken);
        }

        [HttpPost]
        public async Task CreateGame([FromBody] GameRequestCreationDto gameRequestCreationDto, CancellationToken cancellationToken)
        {
            await _gameService.CreateGameAsync(gameRequestCreationDto, cancellationToken);
          
        }

        [HttpPut("{id:guid}")]
        public async Task UpdateGame(Guid id, [FromBody] GameRequestUpdateDto gameRequestUpdateDto, CancellationToken cancellationToken)
        {
            await _gameService.UpdateGameAsync(id, gameRequestUpdateDto, cancellationToken);
        }

        [HttpDelete("{id:guid}")]
        public async Task DeleteGame(Guid id, CancellationToken cancellationToken)
        {
            await _gameService.DeleteGameAsync(id, cancellationToken);
        }
    }
}