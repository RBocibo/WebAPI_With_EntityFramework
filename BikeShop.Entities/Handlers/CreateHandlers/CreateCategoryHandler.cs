using BikeShop.Entities.Commands;
using BikeShop.Entities.Data;
using BikeShop.Entities.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LoggerService;
using Contracts;

namespace BikeShop.Entities.Handlers
{
    public class CreateCategoryHandler : IRequestHandler<AddCategoryCommand, IActionResult>
    {
        private readonly BikeShopContext _context;
        private readonly ILoggerManager _logger;

        public CreateCategoryHandler(BikeShopContext context, ILoggerManager logger)
        {
            _context = context;
            _logger = logger;
        }
        async Task<IActionResult> IRequestHandler<AddCategoryCommand, IActionResult>.Handle(AddCategoryCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = new Category
                {
                    CategoryName = request.Category?.CategoryName ?? string.Empty
                };
                await _context.Categories.AddAsync(entity, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);
                _logger.LogInfo("Return all Category from the database");
                return new OkObjectResult(entity);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return new BadRequestObjectResult(ex.Message);
            }

            return new NoContentResult();
        }
    }
}
