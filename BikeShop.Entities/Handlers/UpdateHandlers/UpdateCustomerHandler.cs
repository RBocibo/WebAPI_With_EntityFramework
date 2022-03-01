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
    public class UpdateCustomerHandler : IRequestHandler<UpdateCustomerCommand, IActionResult>
    {
        private readonly BikeShopContext _context;
        public UpdateCustomerHandler(BikeShopContext context)
        {
            _context = context;
        }

        async Task<IActionResult> IRequestHandler<UpdateCustomerCommand, IActionResult>.Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = _context.Customers.Where(a => a.CustomerId == request.Customer.CustomerId).FirstOrDefault();

            if (customer == null)
            {
                return default;
            }
            else
            {
                customer.FirstName = request.Customer?.FirstName ?? string.Empty;
                customer.LastName = request.Customer?.LastName ?? string.Empty;
                customer.ContactNumber = request.Customer?.ContactNumber ?? string.Empty;
                customer.Email = request.Customer?.Email ?? string.Empty;
                customer.Street = request.Customer?.Street ?? string.Empty;
                customer.City = request.Customer?.City ?? string.Empty;
                customer.Province = request.Customer?.Province ?? string.Empty;
                customer.PostalCode = request.Customer?.PostalCode ?? string.Empty;
                customer.Country = request.Customer?.Country ?? string.Empty;
                _context.Customers.Update(customer);

                await _context.SaveChangesAsync();
                return new OkObjectResult(customer.CustomerId);
            }
        }
    }
}
