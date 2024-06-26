using AutoMapper;
using Shop.BLL.Common.DataTransferObjects.Games;
using Shop.DAL.Models;

namespace Shop.BLL.Common.MappingProfiles; 

public class GameProfile : Profile{ 
    public GameProfile()
    {
        CreateMap<Game, GameResponseDto>();

        CreateMap<Game, GameForOrderResponseDto>();
            
        CreateMap<GameRequestCreationDto, Game>();

        CreateMap<GameRequestUpdateDto, Game>(); 
    }
}