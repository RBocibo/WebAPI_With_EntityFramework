﻿using BikeShop.Entities.Commands;
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
    public class CreateStoreHandler : IRequestHandler<AddStoreCommand, IActionResult>
    {
        private readonly BikeShopContext _context;
        private readonly ILoggerManager _logger;

        public CreateStoreHandler(BikeShopContext context, ILoggerManager logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IActionResult> Handle(AddStoreCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = new Store
                {
                    StoreName = request.Store?.StoreName ?? string.Empty,
                    Contacts = request.Store?.Contacts ?? 0,
                    Email = request.Store?.Email ?? string.Empty,
                    Address = request.Store?.Address ?? string.Empty,
                    ProductId = request.Store?.ProductId ?? 0

                };
                await _context.Stores.AddAsync(entity);
                await _context.SaveChangesAsync();
                _logger.LogInfo("store created");
                return new OkObjectResult(entity);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return new BadRequestObjectResult(ex.Message);
            }
        }
    }
}