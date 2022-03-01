﻿using BikeShop.Entities.Data;
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
        private BikeShopContext _context;
        private readonly ILoggerManager _logger;
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await _mediator.Send(new GetProductsQuery());
        }

        [HttpGet("{id}")]
        public async Task<Product> GetProduct(int id)
        {
            return await _mediator.Send<Product>(new GetProductByIdQuery { Id = id });
        }

        [HttpPost]
        public async Task<ActionResult> CreateProduct([FromBody] AddProductCommand command)
        {
            return (ActionResult)await _mediator.Send(command);
        }

        /*[HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Product product)
        {
            try
            {
                var dbProducts = _context.Products
               .FirstOrDefault(p => p.ProductId == id);

                dbProducts.ProductName = product.ProductName;
                dbProducts.ModelYear = product.ModelYear;
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                _logger.LogError(ex.ToString());
                return BadRequest(ex.Message);
            }

            return NoContent();
        }*/
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
