﻿using BikeShop.Entities.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeShop.Entities.Commands
{
    public class AddCategoryCommand :  IRequest<IActionResult>
    {
        public Category? Category { get; set; }
    }
    
}