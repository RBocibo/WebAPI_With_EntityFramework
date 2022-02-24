using BikeShop.Entities.Data;
using BikeShop.Entities.Models;
using Contracts;
using Microsoft.AspNetCore.Mvc;

namespace BikeShopWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private BikeShopContext _context;
        private readonly ILoggerManager _logger;
        public CustomersController(BikeShopContext context, ILoggerManager loggerManager)
        {
            _context = context;
            _logger = loggerManager;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var customers = _context.Customers;
            return Ok(customers);
        }

        [HttpPost]
        public IActionResult Post(Customer customer)
        {
            try
            {
                if (customer == null)
                {
                    return BadRequest();
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                _context.Customers.Add(customer);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                _logger.LogError(ex.ToString());
                return BadRequest(ex.Message);
            }
            

            return Created("Customers table has been created", customer);

        }

        [HttpPut("{id}")]
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
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var customer = _context.Customers.FirstOrDefault(c => c.CustomerId == id);

                if (customer == null)
                {
                    return BadRequest();
                }

                _context.Remove(customer);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                _logger.LogError(ex.ToString());
                return BadRequest(ex.Message);
            }
            

            return NoContent();

        }
    }
}
