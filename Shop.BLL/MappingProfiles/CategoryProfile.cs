using AutoMapper;
using Shop.BLL.Common.DataTransferObjects.Categories;
using Shop.DAL.Models;

namespace Shop.BLL.Common.MappingProfiles;

public class CategoryProfile : Profile
{
    public CategoryProfile()
    {
        CreateMap<Category, CategoryResponseDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));

        CreateMap<CategoryRequestCreationDto, Category>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));

        CreateMap<CategoryRequestUpdateDto, Category>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
    }
}