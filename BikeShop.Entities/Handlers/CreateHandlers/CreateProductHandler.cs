using BikeShop.Entities.Commands;
using BikeShop.Entities.Data;
using BikeShop.Entities.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Contracts;

namespace BikeShop.Entities.Handlers
{
    public class CreateProductHandler : IRequestHandler<AddProductCommand, IActionResult>
    {
        private readonly BikeShopContext _context;
        private readonly ILoggerManager _logger;

        public CreateProductHandler(BikeShopContext context, ILoggerManager logger)
        {
            _context = context;
            _logger = logger;
        }

        async Task<IActionResult> IRequestHandler<AddProductCommand, IActionResult>.Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = new Product
                {
                    ProductName = request.Product?.ProductName ?? string.Empty,
                    ModelYear = request.Product?.ModelYear ?? 0,
                    Price = request.Product?.Price ?? 0,
                    BrandID = request.Product?.BrandID ?? 0,
                    CategoryID = request.Product?.CategoryID ?? 0

                };
                await _context.Products.AddAsync(entity, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);
                _logger.LogInfo("Return all Product from the database");
                return new OkObjectResult(entity);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return new BadRequestObjectResult(ex.Message);
            }

            return new NoContentResult();
        }
    }
}