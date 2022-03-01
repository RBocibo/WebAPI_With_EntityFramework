using BikeShop.Entities.Commands.UpdateCommands;
using BikeShop.Entities.Data;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeShop.Entities.Handlers.UpdateHandlers
{
    public class UpdateCategoryHandler : IRequestHandler<UpdateCategoryCommand, IActionResult>
    {
        private readonly BikeShopContext _context;
        public UpdateCategoryHandler(BikeShopContext context)
        {
            _context = context;
        }

        async Task<IActionResult> IRequestHandler<UpdateCategoryCommand, IActionResult>.Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = _context.Categories.Where(a => a.CategoryId == request.Category.CategoryId).FirstOrDefault();

            if (category == null)
            {
                return default;
            }
            else
            {
                category.CategoryName = request.Category?.CategoryName ?? string.Empty;
                _context.Categories.Update(category);

                await _context.SaveChangesAsync();
                return new OkObjectResult(category.CategoryId);
            }
        }
    }
}
