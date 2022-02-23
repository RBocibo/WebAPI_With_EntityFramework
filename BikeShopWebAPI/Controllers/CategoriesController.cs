using BikeShop.Entities.Data;
using BikeShop.Entities.Models;
using Microsoft.AspNetCore.Mvc;

namespace BikeShopWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private BikeShopContext _context;

        public CategoriesController(BikeShopContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var categories = _context.Categories.Where(c => c.CategoryName == "Road Bike");
            return Ok(categories);
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
            catch (Exception)
            {

                throw;
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
                var category = _context.Categories.FirstOrDefault(c => c.CategoryId == id);

                if (category == null)
                {
                    return BadRequest();
                }

                _context.Remove(category);
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
