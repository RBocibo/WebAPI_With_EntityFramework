using BikeShop.Entities.Data;
using BikeShop.Entities.Models;
using Contracts;
using Microsoft.AspNetCore.Mvc;

namespace BikeShopWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsControllers : ControllerBase
    {
        private BikeShopContext _context;
        private readonly ILoggerManager _logger;

        public BrandsControllers(BikeShopContext context, ILoggerManager loggerManager)
        {
            _context = context;
            _logger = loggerManager;
        }

       // [Route("Select")]
        [HttpGet]
        public IActionResult Get()
        {
            
            var brands = _context.Brands;
            return Ok(brands);
            //_logger.LogInfo("Accessed Brand Controller and return information");
        }
        //[Route("Insert")]
        [HttpPost]
        public IActionResult Post(Brand brand)
        {
            try
            {
                if (brand == null)
                {
                    return BadRequest();
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                _context.Brands.Add(brand);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                _logger.LogError(ex.ToString());
                return BadRequest(ex.Message);
            }
            
            return Created("Brands table has been created", brand);

        }
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Brand brand)
        {
            try
            {
                if (brand == null)
                {
                    return BadRequest();
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }
                var dbBrand = _context.Brands
                   .FirstOrDefault(b => b.BrandID == id);

                dbBrand.BrandName = brand.BrandName;

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
            _logger.LogWarn("This is a warning");
            try
            {
                var brand = _context.Brands.FirstOrDefault(b => b.BrandID == id);

                if (brand == null)
                {
                    return BadRequest();
                }

                _context.Remove(brand);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return null;//BadRequest(ex.Message);
            }
            
            return NoContent();

        }

    }
}
