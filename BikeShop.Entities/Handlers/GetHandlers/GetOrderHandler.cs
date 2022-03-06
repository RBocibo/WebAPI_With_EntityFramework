using BikeShop.Entities.Data;
using BikeShop.Entities.Models;
using BikeShop.Entities.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BikeShop.Entities.Handlers
{
    public class GetOrderHandler : IRequestHandler<GetOrdersQuery, IEnumerable<Order>>
    {

        private readonly BikeShopContext _context;

        public GetOrderHandler(BikeShopContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Order>> Handle(GetOrdersQuery request, CancellationToken cancellationToken)
        {
            var order = await _context.Orders.ToListAsync();
            return order;
        }

    }

}
