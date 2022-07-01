using Application.Features.Products.Commands.Create;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Product.API.Controllers;

namespace Product.API.UnitTests
{
    public class ProductAPITest
    {
        private readonly Mock<IMediator> _mediatorMock;

        public ProductAPITest()
        {
            _mediatorMock = new Mock<IMediator>();
        }

        [Fact]
        public async Task Get_All_Products_Success()
        {
            //Act
            var productController = new ProductController(_mediatorMock.Object);
            var actionResult = await productController.GetAsync() as OkObjectResult;

            //Assert
            Assert.NotNull(actionResult);
            Assert.Equal(actionResult.StatusCode, (int)System.Net.HttpStatusCode.OK);
        }


        [Fact]
        public async Task Add_Product_Success()
        {
            // Arrange
            var productId = Guid.NewGuid();

            _mediatorMock.Setup(x => x.Send(It.IsAny<CreateProductCommand>(), default(CancellationToken)))
                .Returns(Task.FromResult(productId));

            //Act
            var productController = new ProductController(_mediatorMock.Object);
            var actionResult = await productController.PostAsync(new CreateProductCommand() { Name = "name", Description = "description", Price = 1 }) as OkObjectResult;

            //Assert
            Assert.NotNull(actionResult);
            Assert.Equal(actionResult.StatusCode, (int)System.Net.HttpStatusCode.OK);
            Assert.Equal(actionResult.Value, productId);
        }
    }
}