using BikeShop.Entities.Commands;
using BikeShop.Entities.Data;
using BikeShop.Entities.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Contracts;

namespace BikeShop.Entities.Handlers
{
    public class CreateOrderHandler : IRequestHandler<AddOrderCommand, IActionResult>
    {
        private readonly BikeShopContext _context;
        private readonly ILoggerManager _logger;

        public CreateOrderHandler(BikeShopContext context, ILoggerManager logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IActionResult> Handle(AddOrderCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = new Order
                {
                    RequiredDate = request.Order?.RequiredDate ?? DateTime.Now,
                    ShippedDate = request.Order?.ShippedDate ?? DateTime.Now,
                    OrderDate = request.Order?.OrderDate ?? DateTime.Now,
                    CustomerId = request.Order?.CustomerId ?? 0,
                    StoreId = request.Order?.StoreId ?? 0
                };
                await _context.Orders.AddAsync(entity);
                await _context.SaveChangesAsync();
                _logger.LogInfo("Order created");
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
