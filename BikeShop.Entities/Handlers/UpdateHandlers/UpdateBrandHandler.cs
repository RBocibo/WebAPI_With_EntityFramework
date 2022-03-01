using BikeShop.Entities.Commands.UpdateCommands;
using BikeShop.Entities.Data;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeShop.Entities.Handlers.UpdateHandlers
{
    public class UpdateBrandHandler : IRequestHandler<UpdateBrandCommand, IActionResult>
    {
        private readonly BikeShopContext _context;
        public UpdateBrandHandler(BikeShopContext context)
        {
            _context = context;
        }

        async Task<IActionResult> IRequestHandler<UpdateBrandCommand, IActionResult>.Handle(UpdateBrandCommand request, CancellationToken cancellationToken)
        {
            var brand = _context.Brands.Where(a => a.BrandID == request.Brand.BrandID).FirstOrDefault();

            if (brand == null)
            {
                return default;
            }
            else
            {
                brand.BrandName = request.Brand?.BrandName ?? string.Empty;
                _context.Brands.Update(brand);

                await _context.SaveChangesAsync();
                return new OkObjectResult(brand.BrandID);
            }
        }
    }
}
