using AutoMapper;
using Shop.BLL.Common.DataTransferObjects.Users;
using Shop.DAL.Models;

namespace Shop.BLL.Common.MappingProfiles;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<User, UserResponseDto>(); 

        CreateMap<UserRequestRegistrationDto, User>(); 

        CreateMap<UserRequestUpdateDto, User>(); 
    }
}