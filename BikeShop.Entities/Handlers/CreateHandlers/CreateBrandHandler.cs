﻿using MediatR;
using BikeShop.Entities.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BikeShop.Entities.Data;
using BikeShop.Entities.Models;
using Contracts;
using Microsoft.AspNetCore.Mvc;

namespace BikeShop.Entities.Handlers
{
    public class CreateBrandHandler : IRequestHandler<AddBrandCommand, IActionResult>
    {
        private readonly BikeShopContext _context;
        private readonly ILoggerManager _logger;

        public CreateBrandHandler(BikeShopContext context, ILoggerManager logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IActionResult> Handle(AddBrandCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = new Brand
                {
                    BrandName = request.Brand?.BrandName ?? string.Empty
                };

                await _context.Brands.AddAsync(entity);
                await _context.SaveChangesAsync();
                _logger.LogInfo("Brand added.");
                return new OkObjectResult(entity);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return new BadRequestResult();
            }
        }
    }
}