namespace Application.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Product, GetAllProductsResponseModel>();
        CreateMap<CreateProductCommand, Product>();
    }
}

