using BikeShop.Entities.Data;
using BikeShop.Entities.Models;
using BikeShop.Entities.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeShop.Entities.Handlers
{
    public class GetStoreByIdHandler : IRequestHandler<GetStoreByIdQuery, Store>
    {
        private readonly BikeShopContext _context;

        public GetStoreByIdHandler(BikeShopContext context)
        {
            _context = context;
        }
        public async Task<Store> Handle(GetStoreByIdQuery request, CancellationToken cancellationToken)
        {
            return await _context.Stores.FindAsync(request.Id);
        }
    }
}

