using BikeShop.Entities.Data;
using BikeShop.Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System.Text;

namespace BikeShopWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Product2Controller : ControllerBase
    {
        private readonly BikeShopContext  _context;
        private readonly IDistributedCache _cache;

        public Product2Controller(BikeShopContext context, IDistributedCache cache)
        {
            _context = context;
            _cache = cache;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            bool IsCached = false;
            var cacheKey = "GET_ALL_PRODUCTS";
            List<Product> products = new List<Product>();

            // Get data from cache
            var cachedData = await _cache.GetAsync(cacheKey);
            if (cachedData != null)
            {
                // If data found in cache, encode and deserialize cached data
                var cachedDataString = Encoding.UTF8.GetString(cachedData);
                products = JsonConvert.DeserializeObject<List<Product>>(cachedDataString);
                IsCached = true;
            }
            else
            {
                IsCached = false;
                // If not found, then fetch data from database
                products = await _context.Products.ToListAsync();

                // serialize data
                var cachedDataString = JsonConvert.SerializeObject(products);
                var newDataToCache = Encoding.UTF8.GetBytes(cachedDataString);

                // set cache options 
                var options = new DistributedCacheEntryOptions()
                    .SetAbsoluteExpiration(DateTime.Now.AddMinutes(2))
                    .SetSlidingExpiration(TimeSpan.FromMinutes(1));

                // Add data in cache
                await _cache.SetAsync(cacheKey, newDataToCache, options);
            }

           //return Ok(products);
            return Ok(new { IsCached, products });
        }
    }
}
