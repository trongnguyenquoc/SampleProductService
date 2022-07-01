namespace Application.Features.Products.Queries.GetAll;

public class GetAllProductsQuery : IRequest<IEnumerable<GetAllProductsResponseModel>>
{
}

public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, IEnumerable<GetAllProductsResponseModel>>
{
    private readonly IProductRepositoryAsync _productRepository;
    private readonly IMapper _mapper;

    public GetAllProductsQueryHandler(IProductRepositoryAsync productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<GetAllProductsResponseModel>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
    {
        var products = await _productRepository.GetAllAsync();
        var productView = _mapper.Map<IEnumerable<GetAllProductsResponseModel>>(products);

        return productView;
    }
}

