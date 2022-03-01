using BikeShop.Entities.Data;
using BikeShop.Entities.Models;
using BikeShop.Entities.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BikeShop.Entities.Handlers
{
    public class GetProductHandler : IRequestHandler<GetProductsQuery, IEnumerable<Product>>
    {

        private readonly BikeShopContext _context;

        public GetProductHandler(BikeShopContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Product>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            return await _context.Products.ToListAsync(cancellationToken);
        }
    }

}
