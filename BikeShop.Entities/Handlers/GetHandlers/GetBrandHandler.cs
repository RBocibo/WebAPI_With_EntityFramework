using BikeShop.Entities.Data;
using BikeShop.Entities.Models;
using BikeShop.Entities.Queries;
using Contracts;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

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
             var brand = await _context.Brands.ToListAsync();
             return brand;
        }
    }
}
