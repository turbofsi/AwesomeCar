using System;
using Microsoft.EntityFrameworkCore;
using MVCDemo.DataAccess.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace MVCDemo.DataAccess.Entities
{
    public class AwesomeCarDbContext : IdentityDbContext<User>
    {
        public AwesomeCarDbContext(DbContextOptions options) : base(options)
        {
            
        }
        public DbSet<AwesomeCar> AwesomeCars { get; set; }
    }
}
