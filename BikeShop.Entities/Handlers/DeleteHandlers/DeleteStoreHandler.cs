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
    public class DeleteStoreHandler : IRequestHandler<DeleteStoreCommand, Unit>
    {
        private readonly BikeShopContext _context;

        public DeleteStoreHandler(BikeShopContext context)
        {
            _context = context;
        }
        public async Task<Unit> Handle(DeleteStoreCommand request, CancellationToken cancellationToken)
        {
            var store = await _context.Stores.FindAsync(request.Id);
            if (store == null)
                return Unit.Value;

            _context.Stores.Remove(store);
            //store.IsDeleted = true;
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}

