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
    }
}
