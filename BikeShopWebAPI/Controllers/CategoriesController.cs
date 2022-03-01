using BikeShop.Entities.Data;
using BikeShop.Entities.Models;
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
    public class CategoriesController : ControllerBase
    {
        private BikeShopContext _context;
        private readonly ILoggerManager _logger;
        private readonly IMediator _mediator;

        public CategoriesController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IEnumerable<Category>> GetCategories()
        {
            return await _mediator.Send(new GetCategoriesQuery());
        }

        [HttpGet("{id}")]
        public async Task<Category> GetCategory(int id)
        {
            return await _mediator.Send<Category>(new GetCategoryByIdQuery { Id = id });
        }

        [HttpPost]
        public async Task<ActionResult> CreateCategory([FromBody] AddCategoryCommand command)
        {
            return (ActionResult)await _mediator.Send(command);
        }

        [HttpPut("{id}")]
        /*public IActionResult Put(int id, [FromBody] Category category)
        {
            try
            {
                var dbCategories = _context.Categories
              .FirstOrDefault(c => c.CategoryId == id);

                dbCategories.CategoryName = category.CategoryName;

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
