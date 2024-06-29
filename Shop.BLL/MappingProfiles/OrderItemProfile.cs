using AutoMapper;
using Shop.BLL.Common.DataTransferObjects.OrderItems;
using Shop.DAL.Models;

namespace Shop.BLL.Common.MappingProfiles;

public class OrderItemProfile : Profile
{
    public OrderItemProfile()
    {
        CreateMap<OrderItem, OrderItemResponseDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Game, opt => opt.MapFrom(src => src.Game))
            .ForMember(dest => dest.Count, opt => opt.MapFrom(src => src.Count)); 

        CreateMap<OrderItemRequestCreationDto, OrderItem>()
            .ForMember(dest => dest.GameId, opt => opt.MapFrom(src => src.GameId))
            .ForMember(dest => dest.Count, opt => opt.MapFrom(src => src.Count));
    }
}