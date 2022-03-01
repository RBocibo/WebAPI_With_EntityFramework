using BikeShop.Entities.Data;
using BikeShop.Entities.Models;
using BikeShop.Entities.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BikeShop.Entities.Handlers
{
    public class GetCustomerHandler : IRequestHandler<GetCustomersQuery, IEnumerable<Customer>>
    { 

        private readonly BikeShopContext _context;

        public GetCustomerHandler(BikeShopContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Customer>> Handle(GetCustomersQuery request, CancellationToken cancellationToken)
        {
            return await _context.Customers.ToListAsync(cancellationToken);
        }


    }
}
