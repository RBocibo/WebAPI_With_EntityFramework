using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BikeShop.Entities.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BikeShop.Entities.Commands
{
    public class AddStoreCommand : IRequest<IActionResult>
    {
        public Store? Store { get; set; }

    }
}
