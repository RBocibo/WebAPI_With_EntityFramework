using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BikeShop.Entities.Models;
using MediatR;

namespace BikeShop.Entities.Queries
{
    public class GetBrandsQuery : IRequest<IEnumerable<Brand>>
    {
    }
}
