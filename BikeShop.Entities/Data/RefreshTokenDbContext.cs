using BikeShop.Entities.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeShop.Entities.Data
{
    public class RefreshTokenDbContext : IdentityDbContext<ApplicationUser>
    {
        public RefreshTokenDbContext(DbContextOptions<RefreshTokenDbContext> options)
            : base(options)
        {

        }
        //public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
