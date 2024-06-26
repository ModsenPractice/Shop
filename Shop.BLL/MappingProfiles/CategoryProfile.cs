using AutoMapper;
using Shop.BLL.Common.DataTransferObjects.Categories;
using Shop.DAL.Models;

namespace Shop.BLL.Common.MappingProfiles;

public class CategoryProfile : Profile
{
    public CategoryProfile()
    {
        CreateMap<Category, CategoryResponseDto>(); 

        CreateMap<CategoryRequestCreationDto, Category>();

        CreateMap<CategoryRequestUpdateDto, Category>(); 
    }
}