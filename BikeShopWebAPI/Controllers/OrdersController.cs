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
    public class OrdersController : ControllerBase
    {
        private BikeShopContext _context;
        private readonly ILoggerManager _logger;
        private readonly IMediator _mediator;
        public OrdersController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IEnumerable<Order>> GetOrders()
        {
            return await _mediator.Send(new GetOrdersQuery());
        }

        [HttpGet("{id}")]
        public async Task<Order> GetOrder(int id)
        {
            return await _mediator.Send<Order>(new GetOrderByIdQuery { Id = id });
        }

        [HttpPost]
        public async Task<ActionResult> CreateOrder([FromBody] AddOrderCommand command)
        {
            return (ActionResult)await _mediator.Send(command);
        }

        /*[HttpPut("{id}")]
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
            catch (Exception ex)
            {

                _logger.LogError(ex.ToString());
                return BadRequest(ex.Message);
            }
            

            return NoContent();
        }*/
        [HttpPut]
        public async Task<ActionResult> UpdateOrder([FromBody] UpdateOrderCommand command)
        {

            return (ActionResult)await _mediator.Send(command);

        }

        [HttpDelete]
        public async Task<ActionResult> DeleteOrder(int id)
        {
            await _mediator.Send(new DeleteOrderCommand { Id = id });
            return NoContent();
        }

    }


}
