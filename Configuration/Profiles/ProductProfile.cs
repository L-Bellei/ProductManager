using AutoMapper;
using Microsoft.OpenApi.Extensions;
using ProductManager.Domain.Entities;
using ProductManager.Domain.Views;

namespace ProductManager.Configuration.Profiles;

public class ProductProfile : Profile
{
    public ProductProfile()
    {
        CreateMap<Product, ProductView>()
            .ForMember(dest => dest.Category, src => src.MapFrom(value => value.Category.GetDisplayName()));
    }
}
