using BikeShop.Entities.Data;
using BikeShop.Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Contracts;
using MediatR;
using BikeShop.Entities.Queries;
using BikeShop.Entities.Commands;
using BikeShop.Entities.Commands.UpdateCommands;
using Microsoft.AspNetCore.Authorization;

namespace BikeShopWebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoriesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IEnumerable<Category>> GetCategories()
        {
            var category = await _mediator.Send(new GetCategoriesQuery());

            return category;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategory(int id)
        {
            var category = await _mediator.Send<Category>(new GetCategoryByIdQuery { Id = id });
            return category == null ? NotFound() : Ok(category);
        }

        [HttpPost]
        public async Task<ActionResult> CreateCategory([FromBody] AddCategoryCommand command)
        {
            return (ActionResult)await _mediator.Send(command);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateCategory([FromBody] UpdateCategoryCommand command)
        {

            return (ActionResult)await _mediator.Send(command);

        }

        [HttpDelete]
        public async Task<ActionResult> DeleteCategory(int id)
        {
            await _mediator.Send(new DeleteCategoryCommand { Id = id });
            return NoContent();
        }
    }
}
