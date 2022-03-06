using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BikeShop.Entities.Commands;
using BikeShop.Entities.Data;
using MediatR;

namespace BikeShop.Entities.Handlers
{
    public class DeleteBrandHandler : IRequestHandler<DeleteBrandCommand, Unit>
    {
        private readonly BikeShopContext _context;

        public DeleteBrandHandler(BikeShopContext context)
        {
            _context = context;
        }
        public async Task<Unit> Handle(DeleteBrandCommand request, CancellationToken cancellationToken)
        {
            var brand = await _context.Orders.FindAsync(request.Id);
            if (brand == null)
                return Unit.Value;

            _context.Orders.Remove(brand);
            await _context.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
