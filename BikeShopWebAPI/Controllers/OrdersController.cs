using BikeShop.Entities.Data;
using BikeShop.Entities.Models;
using Microsoft.AspNetCore.Mvc;

namespace BikeShopWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private BikeShopContext _context;

        public OrdersController(BikeShopContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var oders = _context.Orders;
            return Ok(oders);
        }

        [HttpPost]
        public IActionResult Post(Order order)
        {
            try
            {
                if (order == null)
                {
                    return BadRequest();
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                _context.Orders.Add(order);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
            

            return Created($"Orders table has been created", order);

        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Order order)
        {
            try
            {
                var dbOrder = _context.Orders
               .FirstOrDefault(o => o.OrderId == id);

                dbOrder.RequiredDate = order.RequiredDate;
                dbOrder.ShippedDate = order.ShippedDate;

                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
            

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var orders = _context.Orders.FirstOrDefault(o => o.OrderId == id);

                if (orders == null)
                {
                    return BadRequest();
                }

                _context.Remove(orders);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
            
            return NoContent();

        }

    }


}
