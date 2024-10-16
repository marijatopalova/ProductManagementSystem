using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProductManagementSystem.Application.Commands.CreateProduct;
using ProductManagementSystem.Application.Commands.DeleteProduct;
using ProductManagementSystem.Application.Commands.UpdateProduct;
using ProductManagementSystem.Application.Queries.GetAllProducts;
using ProductManagementSystem.Application.Queries.GetProductById;
using ProductManagementSystem.Domain.Entities;

namespace ProductManagementSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController(IMediator mediator) : ControllerBase
    {
        [HttpGet("/products")]
        public async Task<ActionResult<List<Product>>> GetAllAsync()
        {
            var products = await mediator.Send(new GetAllProductsQuery());

            return Ok(products);
        }

        [HttpGet("/products/{id}")]
        public async Task<ActionResult<Product>> GetByIdAsync(int id)
        {
            var product = await mediator.Send(new GetProductByIdQuery(id));

            return Ok(product);
        }

        [HttpPost("/products")]
        public async Task<ActionResult<int>> CreateAsync([FromBody] Product product)
        {
            var productId = await mediator.Send(new CreateProductCommand(product));

            return Ok(productId);
        }

        [HttpPut("/products")]
        public async Task<ActionResult> UpdateAsync([FromBody] Product product)
        {
            await mediator.Send(new UpdateProductCommand(product));

            return Ok();
        }

        [HttpDelete("/products/{id}")]
        public async Task<ActionResult<bool>> DeleteAsync(int id)
        {
            var isDeleted = await mediator.Send(new DeleteProductCommand(id));

            return Ok(isDeleted);
        }
    }
}
