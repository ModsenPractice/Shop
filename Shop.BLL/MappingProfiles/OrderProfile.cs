using AutoMapper;
using Shop.BLL.Common.DataTransferObjects.Orders;
using Shop.DAL.Models;

namespace Shop.BLL.Common.MappingProfiles;

public class OrderProfile : Profile
{
    public OrderProfile()
    {
        CreateMap<Order, OrderResponseDto>(); 

        CreateMap<OrderRequestCreationDto, Order>();
    }
}