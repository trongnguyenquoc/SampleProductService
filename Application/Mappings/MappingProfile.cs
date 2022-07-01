using Application.Features.Products.Commands.Create;
using Application.Features.Products.Queries.GetAll;
using AutoMapper;
using Domain.Entities;

namespace Application.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Product, GetAllProductsResponseModel>();
        CreateMap<CreateProductCommand, Product>();
    }
}

