using BikeShop.Entities.Commands;
using BikeShop.Entities.Commands.UpdateCommands;
using BikeShop.Entities.Data;
using BikeShop.Entities.Models;
using BikeShop.Entities.Queries;
using Contracts;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BikeShopWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsControllers : ControllerBase
    {
        private readonly IMediator _mediator;

        public BrandsControllers(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IEnumerable<Brand>> GetBrands()
        {
            var brand = await _mediator.Send(new GetBrandsQuery());
            return brand;
            
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBrand(int id)
        {
            var brand = await _mediator.Send<Brand>(new GetBrandByIdQuery { Id = id});
            return brand == null ? NotFound() : Ok(brand); 
        }

        [HttpPost]
        public async Task<ActionResult> CreateBrand([FromBody] AddBrandCommand command)
        {

            var brands = (ActionResult)await _mediator.Send(command);
            return Ok(brands);
        }

        [HttpPut]
          //[Route("Update")]
          public async Task<ActionResult> UpdateBrand([FromBody] UpdateBrandCommand command)
          {

              return (ActionResult)await _mediator.Send(command);

          }

        [HttpDelete]
        public async Task<ActionResult> DeleteBrand(int id)
        {
            await _mediator.Send(new DeleteBrandCommand { Id = id });
            return NoContent();
        }
    }
}
