using BikeShop.Entities.Data;
using BikeShop.Entities.Models;
using BikeShop.Entities.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BikeShop.Entities.Handlers
{
    public class GetStoreHandler : IRequestHandler<GetStoresQuery, IEnumerable<Store>>
    {

        private readonly BikeShopContext _context;

        public GetStoreHandler(BikeShopContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Store>> Handle(GetStoresQuery request, CancellationToken cancellationToken)
        {
            //var store = await _context.Stores.ToListAsync();
            var store = _context.Stores.IgnoreQueryFilters()
                    .Where(s => EF.Property<bool>(s, "IsDeleted") == false);
            return store;
         }
    }

}
