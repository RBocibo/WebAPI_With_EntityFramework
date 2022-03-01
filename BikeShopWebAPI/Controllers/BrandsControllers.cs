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
        private readonly ILoggerManager _logger;
        private readonly IMediator _mediator;

        public BrandsControllers(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IEnumerable<Brand>> GetBrands()
        {
            return await _mediator.Send(new GetBrandsQuery());
        }

        [HttpGet("{id}")]
        public async Task<Brand> GetBrand(int id)
        {
            return await _mediator.Send<Brand>(new GetBrandByIdQuery { Id = id});
        }

        [HttpPost]
        public async Task<ActionResult> CreateBrand([FromBody] AddBrandCommand command)
        {

            return (ActionResult)await _mediator.Send(command);

        }

        [HttpPut]
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
