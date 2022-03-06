using BikeShop.Entities.Data;
using BikeShop.Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Contracts;
using MediatR;
using BikeShop.Entities.Queries;
using BikeShop.Entities.Commands;
using BikeShop.Entities.Commands.UpdateCommands;

namespace BikeShopWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoresController : ControllerBase
    {
        private readonly IMediator _mediator;
        public StoresController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        [Route("GetAll")]
        public async Task<IEnumerable<Store>> GetStores()
        {
            return await _mediator.Send(new GetStoresQuery());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStore(int id)
        {
            var store = await _mediator.Send<Store>(new GetStoreByIdQuery { Id = id });
            return store == null ? NotFound() : Ok(store);
        }

        [HttpPost]
        public async Task<ActionResult> CreateStore([FromBody] AddStoreCommand command)
        {
            return (ActionResult)await _mediator.Send(command);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateStore([FromBody] UpdateStoreCommand command)
        {

            return (ActionResult)await _mediator.Send(command);

        }

        [HttpDelete]
        public async Task<ActionResult> DeleteStore(int id)
        {
            await _mediator.Send(new DeleteStoreCommand { Id = id });
            return NoContent();
        }

    }
}
