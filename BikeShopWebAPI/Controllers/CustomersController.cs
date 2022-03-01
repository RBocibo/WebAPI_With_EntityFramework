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
        private BikeShopContext _context;
        private readonly ILoggerManager _logger;
        private readonly IMediator _mediator;

        public CustomersController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IEnumerable<Customer>> GetCustomers()
        {
            return await _mediator.Send(new GetCustomersQuery());
        }

        [HttpGet("{id}")]
        public async Task<Customer> GetCustomer(int id)
        {
            return await _mediator.Send<Customer>(new GetCustomerByIdQuery { Id = id });
        }

        [HttpPost]
        public async Task<ActionResult> CreateCustomer([FromBody] AddCustomerCommand command)
        {
            return (ActionResult)await _mediator.Send(command);

        }

        /*[HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Customer customer)
        {
            try
            {
                var dbCustomers = _context.Customers
              .FirstOrDefault(c => c.CustomerId == id);

                dbCustomers.FirstName = customer.FirstName;
                dbCustomers.LastName = customer.LastName;
                dbCustomers.ContactNumber = customer.ContactNumber;
                dbCustomers.Email = customer.Email;
                dbCustomers.Street = customer.Street;
                dbCustomers.City = customer.City;
                dbCustomers.Country = customer.Country;
                dbCustomers.Province = customer.Province;
                dbCustomers.PostalCode = customer.PostalCode;

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
