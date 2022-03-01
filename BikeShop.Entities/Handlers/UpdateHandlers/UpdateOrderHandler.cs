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
    public class UpdateOrderHandler : IRequestHandler<UpdateOrderCommand, IActionResult>
    {
        private readonly BikeShopContext _context;
        public UpdateOrderHandler(BikeShopContext context)
        {
            _context = context;
        }

        async Task<IActionResult> IRequestHandler<UpdateOrderCommand, IActionResult>.Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = _context.Orders.Where(a => a.OrderId == request.Order.OrderId).FirstOrDefault();

            if (order == null)
            {
                return default;
            }
            else
            {
                order.OrderDate = request.Order?.OrderDate ?? default(DateTime);
                order.RequiredDate = request.Order?.RequiredDate ?? default(DateTime);
                order.ShippedDate = request.Order?.ShippedDate ?? default(DateTime);
                _context.Orders.Update(order);

                await _context.SaveChangesAsync();
                return new OkObjectResult(order.OrderId);
            }
        }
    }
}
