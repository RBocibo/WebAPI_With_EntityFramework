using BikeShop.Entities.Commands;
using BikeShop.Entities.Data;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeShop.Entities.Handlers
{
    public class DeleteOrderHandler : IRequestHandler<DeleteOrderCommand, Unit>
    {
        private readonly BikeShopContext _context;

        public DeleteOrderHandler(BikeShopContext context)
        {
            _context = context;
        }
        public async Task<Unit> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
            var order = await _context.Orders.FindAsync(request.Id);
            if (order == null)
                return Unit.Value;

            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
