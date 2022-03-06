﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BikeShop.Entities.Data;
using BikeShop.Entities.Models;
using BikeShop.Entities.Queries;
using Contracts;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BikeShop.Entities.Handlers
{
    public class GetBrandByIdHandler : IRequestHandler<GetBrandByIdQuery, Brand>
    {
        private readonly BikeShopContext _context;

        public GetBrandByIdHandler(BikeShopContext context)
        {
            _context = context;
        }
        public async Task<Brand> Handle(GetBrandByIdQuery request, CancellationToken cancellationToken)
        {
            var brand = await _context.Brands.FindAsync(request.Id);
            return brand;    
        }
    }
}
