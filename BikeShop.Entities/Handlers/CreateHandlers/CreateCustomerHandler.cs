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
using Contracts;

namespace BikeShop.Entities.Handlers
{
    public class CreateCustomerHandler : IRequestHandler<AddCustomerCommand, IActionResult>
    {
        private readonly BikeShopContext _context;
        private readonly ILoggerManager _logger;

        public CreateCustomerHandler(BikeShopContext context, ILoggerManager logger)
        {
            _context = context;
            _logger = logger;
        }
        async Task<IActionResult> IRequestHandler<AddCustomerCommand, IActionResult>.Handle(AddCustomerCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = new Customer
                {
                    FirstName = request.Customer?.FirstName ?? string.Empty,
                    LastName = request.Customer?.LastName ?? string.Empty,
                    ContactNumber = request.Customer?.ContactNumber ?? string.Empty,
                    Email = request.Customer?.Email ?? string.Empty,
                    Street = request.Customer?.Street ?? string.Empty,
                    City = request.Customer?.City ?? string.Empty,
                    Province = request.Customer?.Province ?? string.Empty,
                    PostalCode = request.Customer?.PostalCode ?? string.Empty,
                    Country = request.Customer?.Country ?? string.Empty
                };
                await _context.Customers.AddAsync(entity, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);
                _logger.LogInfo("Return all Customer from the database");
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
