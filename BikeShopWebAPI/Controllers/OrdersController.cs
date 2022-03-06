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
        private readonly IMediator _mediator;
        public OrdersController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        [Route("GetAll")]
        public async Task<IEnumerable<Order>> GetOrders()
        {
            return await _mediator.Send(new GetOrdersQuery());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrder(int id)
        {
            var order = await _mediator.Send<Order>(new GetOrderByIdQuery { Id = id });
            return order == null ? NotFound() : Ok(order);
        }

        [HttpPost]
        public async Task<ActionResult> CreateOrder([FromBody] AddOrderCommand command)
        {
            return (ActionResult)await _mediator.Send(command);
        }

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
