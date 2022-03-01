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
        private BikeShopContext _context;
        private readonly ILoggerManager _logger;
        private readonly IMediator _mediator;

        public StoresController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IEnumerable<Store>> GetStores()
        {
            return await _mediator.Send(new GetStoresQuery());
        }

        [HttpGet("{id}")]
        public async Task<Store> GetStore(int id)
        {
            return await _mediator.Send<Store>(new GetStoreByIdQuery { Id = id });
        }

        [HttpPost]
        public async Task<ActionResult> CreateStore([FromBody] AddStoreCommand command)
        {
            return (ActionResult)await _mediator.Send(command);
        }

        /*[HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Store store)
        {
            try
            {
                var dbStores = _context.Stores
                .FirstOrDefault(p => p.StoreId == id);

                dbStores.Address = store.Address;
                dbStores.Email = store.Email;

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
