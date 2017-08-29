using System;
using Microsoft.EntityFrameworkCore;
using MVCDemo.DataAccess.Models;

namespace MVCDemo.DataAccess.Entities
{
    public class AwesomeCarDbContext : DbContext
    {
        public AwesomeCarDbContext(DbContextOptions options) : base(options)
        {
            
        }
        public DbSet<AwesomeCar> AwesomeCars { get; set; }

        internal AwesomeCar FirstOrDefault()
        {
            throw new NotImplementedException();
        }
    }
}
