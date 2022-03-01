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
    public class UpdateProductHandler : IRequestHandler<UpdateProductCommand, IActionResult>
    {
        private readonly BikeShopContext _context;
        public UpdateProductHandler(BikeShopContext context)
        {
            _context = context;
        }

        async Task<IActionResult> IRequestHandler<UpdateProductCommand, IActionResult>.Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = _context.Products.Where(a => a.ProductId == request.Product.ProductId).FirstOrDefault();

            if (product == null)
            {
                return default;
            }
            else
            {
                product.ProductName = request.Product?.ProductName ?? String.Empty;
                product.ModelYear = request.Product?.ModelYear ?? 0;
                product.Price = request.Product?.Price ?? 0;
                product.BrandID = request.Product?.BrandID ?? 0;
                product.CategoryID = request.Product?.CategoryID ?? 0;
                _context.Products.Update(product);

                await _context.SaveChangesAsync();
                return new OkObjectResult(product.ProductId);
            }
        }
    }
}
