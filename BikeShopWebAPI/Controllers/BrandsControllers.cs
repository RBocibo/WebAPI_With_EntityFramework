using BikeShop.Entities.Data;
using BikeShop.Entities.Models;
using Microsoft.AspNetCore.Mvc;

namespace BikeShopWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsControllers : ControllerBase
    {
        private BikeShopContext _context;

        public BrandsControllers(BikeShopContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var brands = _context.Brands;
            return Ok(brands);
        }

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
            catch (Exception)
            {

                throw;
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
                Console.WriteLine(ex);
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
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
            catch (Exception)
            {

                throw;
            }
            
            return NoContent();

        }

    }
}
