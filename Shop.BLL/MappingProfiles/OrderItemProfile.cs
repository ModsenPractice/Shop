using AutoMapper;
using Shop.BLL.Common.DataTransferObjects.OrderItems;
using Shop.DAL.Models;

namespace Shop.BLL.Common.MappingProfiles;

public class OrderItemProfile : Profile
{
    public OrderItemProfile()
    {
        CreateMap<OrderItem, OrderItemResponseDto>(); 

        CreateMap<OrderItemRequestCreationDto, OrderItem>();
    }
}