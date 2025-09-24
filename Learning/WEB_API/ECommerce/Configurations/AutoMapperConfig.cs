using System;
using AutoMapper;
using ECommerce.Models;

namespace ECommerce.Configurations;

public class AutoMapperConfig : Profile
{
    public AutoMapperConfig()
    {
        CreateMap<Products, CreateProductDTO>().ReverseMap();
        CreateMap<Products, ProductResponseDTO>().ReverseMap();
    }
}
