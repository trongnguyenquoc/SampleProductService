using Application.Features.Products.Commands.Create;
using Application.Features.Products.Queries.GetAll;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Product.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            return Ok(await _mediator.Send(new GetAllProductsQuery()));
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(CreateProductCommand product)
        {
            return Ok(await _mediator.Send(product));
        }
    }
}
