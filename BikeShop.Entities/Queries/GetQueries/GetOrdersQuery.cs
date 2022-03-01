using BikeShop.Entities.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeShop.Entities.Queries
{
    public class GetOrdersQuery : IRequest<IEnumerable<Order>>
    {
    }
}
