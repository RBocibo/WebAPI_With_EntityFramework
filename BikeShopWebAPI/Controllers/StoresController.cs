using BikeShop.Entities.Data;
using BikeShop.Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BikeShopWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoresController : ControllerBase
    {
        private BikeShopContext _context;

        public StoresController(BikeShopContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var stores = _context.Stores;
            return Ok(stores);
        }

        [HttpPost]
        public IActionResult Post(Store store)
        {
            try
            {
                if (store == null)
                {
                    return BadRequest();
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                _context.Stores.Add(store);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
            
            return Created("Stores table has been created", store);

        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Store store)
        {
            try
            {
                var dbStores = _context.Stores
                .FirstOrDefault(p => p.StoreId == id);

                dbStores.Address = store.Address;
                dbStores.Email = store.Email;

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
                var store = _context.Stores.FirstOrDefault(s => s.StoreId == id);

                if (store == null)
                {
                    return BadRequest();
                }

                _context.Remove(store);
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
