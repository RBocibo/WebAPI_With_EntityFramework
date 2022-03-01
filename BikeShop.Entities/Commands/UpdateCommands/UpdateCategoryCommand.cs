using BikeShop.Entities.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BikeShop.Entities.Commands.UpdateCommands
{
    public class UpdateCategoryCommand : IRequest<IActionResult>
    {
        public Category? Category { get; set; }
    }
}
