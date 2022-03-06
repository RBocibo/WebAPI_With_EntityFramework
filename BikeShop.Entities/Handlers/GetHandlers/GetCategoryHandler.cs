using BikeShop.Entities.Data;
using BikeShop.Entities.Models;
using BikeShop.Entities.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace BikeShop.Entities.Handlers
{
    public class GetCategoryHandler : IRequestHandler<GetCategoriesQuery, IEnumerable<Category>>
    {
        private readonly BikeShopContext _context;

        public GetCategoryHandler(BikeShopContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Category>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
        {
            var category = await _context.Categories.ToListAsync();
            return category;
        }
    }
}
