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
    public class CustomersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CustomersController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        [Route("GetAll")]
        public async Task<IEnumerable<Customer>> GetCustomers()
        {
            return await _mediator.Send(new GetCustomersQuery());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomer(int id)
        {
            var customer = await _mediator.Send<Customer>(new GetCustomerByIdQuery { Id = id });
            return customer == null ? NotFound() : Ok(customer);
        }

        [HttpPost]
        public async Task<ActionResult> CreateCustomer([FromBody] AddCustomerCommand command)
        {
            return (ActionResult)await _mediator.Send(command);

        }
        
        [HttpPut]
        public async Task<ActionResult> UpdateCustomer([FromBody] UpdateCustomerCommand command)
        {

            return (ActionResult)await _mediator.Send(command);

        }

        [HttpDelete]
        public async Task<ActionResult> DeleteCustomer(int id)
        {
            await _mediator.Send(new DeleteCustomerCommand { Id = id });
            return NoContent();
        }
    }
}
