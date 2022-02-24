using BikeShop.Entities.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BikeShop.Entities.Models;
using Contracts;

namespace BikeShopWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private BikeShopContext _context;
        private readonly ILoggerManager _logger;

        public ProductsController(BikeShopContext context, ILoggerManager loggerManager)
        {
            _context = context;
            _logger = loggerManager;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var products = _context.Products;
            return Ok(products);
        }
        [HttpPost]
        public IActionResult Post([FromBody] Product products)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }
                if (products == null)
                {
                    return BadRequest();
                }


                _context.Products.Add(products);

                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return BadRequest(ex.Message);
            }

            return Created("Products table has been created", products);

        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Product product)
        {
            try
            {
                var dbProducts = _context.Products
               .FirstOrDefault(p => p.ProductId == id);

                dbProducts.ProductName = product.ProductName;
                dbProducts.ModelYear = product.ModelYear;
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
                var product = _context.Products.FirstOrDefault(p => p.ProductId == id);

                if (product == null)
                {
                    return BadRequest();
                }

                _context.Remove(product);
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
