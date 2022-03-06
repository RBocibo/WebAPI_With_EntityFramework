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

        public async Task<IActionResult> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = new Product
                {
                    ProductName = request.Product?.ProductName ?? string.Empty,
                    ModelYear = request.Product?.ModelYear ?? 0,
                    Price = request.Product?.Price ?? 0,
                    BrandId = request.Product?.BrandId ?? 0,
                    CategoryId = request.Product?.CategoryId ?? 0

                };
                await _context.Products.AddAsync(entity);
                await _context.SaveChangesAsync();
                _logger.LogInfo("New Product created");
                return new OkObjectResult(entity);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return new BadRequestObjectResult(ex.Message);
            }
        }
    }
}