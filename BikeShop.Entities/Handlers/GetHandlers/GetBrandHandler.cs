using BikeShop.Entities.Data;
using BikeShop.Entities.Models;
using BikeShop.Entities.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeShop.Entities.Handlers
{
    public class GetBrandHandler : IRequestHandler<GetBrandsQuery, IEnumerable<Brand>>
    {
        private readonly BikeShopContext _context;

        public GetBrandHandler(BikeShopContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Brand>> Handle(GetBrandsQuery request, CancellationToken cancellationToken)
        {
            return await _context.Brands.ToListAsync(cancellationToken);
        }
    }
}
