using BikeShop.Entities.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeShop.Entities.Commands.UpdateCommands
{
    public class UpdateStoreCommand : IRequest<IActionResult>
    {
        public Store? Store { get; set; }
    }
}
