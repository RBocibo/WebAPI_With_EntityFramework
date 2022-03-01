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
    public class GetCustomerByIdHandler :IRequestHandler<GetCustomerByIdQuery, Customer>
    {
        private readonly BikeShopContext _context;

    public GetCustomerByIdHandler(BikeShopContext context)
    {
        _context = context;
    }
    public async Task<Customer> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
    {
        return await _context.Customers.FindAsync(request.Id);
    }
}
}