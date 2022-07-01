using Application.Features.Products.Queries.GetAll;
using Application.Interfaces;
using AutoMapper;
using Moq;

namespace Product.API.UnitTests
{
    public class GetAllProductsQueryHandlerTest
    {
        private readonly Mock<IProductRepositoryAsync> _productRepoMock;
        private readonly Mock<IMapper> _mapper;

        public GetAllProductsQueryHandlerTest()
        {
            _productRepoMock = new Mock<IProductRepositoryAsync>();
            _mapper = new Mock<IMapper>();
        }

        [Fact]
        public async Task Return_All_Product_Success()
        {
            // Arrange
            var domainProducts = FakeDomainProducts();
            var products = FakeProducts();

            _productRepoMock.Setup(repo => repo.GetAllAsync())
                .Returns(Task.FromResult(domainProducts));

            _mapper.Setup(x => x.Map<IEnumerable<GetAllProductsResponseModel>>(domainProducts))
                .Returns(products);

            //Act
            var handler = new GetAllProductsQueryHandler(_productRepoMock.Object, _mapper.Object);
            var cltToken = new System.Threading.CancellationToken();

            var result = await handler.Handle(It.IsAny<GetAllProductsQuery>(), cltToken);

            //Assert
            Assert.Equal(products, result);
        }

        private IReadOnlyList<Domain.Entities.Product> FakeDomainProducts()
        {
            IReadOnlyList<Domain.Entities.Product> products = new List<Domain.Entities.Product>()
            {
                new Domain.Entities.Product
                {
                    Id = Guid.NewGuid(),
                    Name="fakeName",
                    Description="fakeDescription",
                    Price = 1
                }
            };

            return products;
        }

        private IEnumerable<GetAllProductsResponseModel> FakeProducts()
        {
            IEnumerable<GetAllProductsResponseModel> products = new List<GetAllProductsResponseModel>()
            {
                new GetAllProductsResponseModel
                {
                    Id = Guid.NewGuid(),
                    Name="fakeName",
                    Description="fakeDescription",
                    Price = 1
                }
            };

            return products;
        }
    }
}
