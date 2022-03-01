using BikeShop.Entities.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BikeShop.Entities.Commands.UpdateCommands
{
    public class UpdateCustomerCommand : IRequest<IActionResult>
    {
        public Customer? Customer { get; set; }
    }
}
