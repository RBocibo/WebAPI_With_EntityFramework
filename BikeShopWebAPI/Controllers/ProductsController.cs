using BikeShop.Entities.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BikeShop.Entities.Models;
using Contracts;
using MediatR;
using BikeShop.Entities.Queries;
using BikeShop.Entities.Commands;
using BikeShop.Entities.Commands.UpdateCommands;

namespace BikeShopWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        [Route("GetAll")]
        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await _mediator.Send(new GetProductsQuery());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var product = await _mediator.Send<Product>(new GetProductByIdQuery { Id = id });
            return product == null ? NotFound() : Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult> CreateProduct([FromBody] AddProductCommand command)
        {
            return (ActionResult)await _mediator.Send(command);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateProduct([FromBody] UpdateProductCommand command)
        {

            return (ActionResult)await _mediator.Send(command);

        }

        [HttpDelete]
        public async Task<ActionResult> DeleteProduct(int id)
        {
            await _mediator.Send(new DeleteProductCommand { Id = id });
            return NoContent();
        }
    }
}
