using BikeShop.Entities.Data;
using BikeShop.Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Contracts;

namespace BikeShopWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private BikeShopContext _context;
        private readonly ILoggerManager _logger;

        public CategoriesController(BikeShopContext context, ILoggerManager loggerManager)
        {
            _context = context;
            _logger = loggerManager;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var categories = _context.Categories;
            return Ok(categories);
            //_logger.LogInfo("Accessed Categories Controller and return information");
        }
        [HttpPost]
        public IActionResult Post( Category category)
        {
            try
            {
                if (category == null)
                {
                    return BadRequest();
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                _context.Categories.Add(category);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                _logger.LogError(ex.ToString());
                return BadRequest(ex.Message);
            }

            return Created("Categories table has been created", category);

        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Category category)
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
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var category = _context.Categories.FirstOrDefault(c => c.CategoryId == id);

                if (category == null)
                {
                    return BadRequest();
                }

                _context.Remove(category);
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
