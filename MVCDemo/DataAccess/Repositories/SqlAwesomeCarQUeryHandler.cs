using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVCDemo.DataAccess.Models;
using MVCDemo.DataAccess.Entities;

namespace MVCDemo.DataAccess.Repositories
{
    public class SqlAwesomeCarQUeryHandler : IAwesomeCarQueryHandler
    {
        private AwesomeCarDbContext _context;

        public SqlAwesomeCarQUeryHandler(AwesomeCarDbContext context)
        {
            _context = context;
        }
        public void Add(AwesomeCar car)
        {
            _context.Add(car);
            _context.SaveChanges();
        }

        public IEnumerable<AwesomeCar> GetAwesomeCars()
        {
            return _context.AwesomeCars;
        }
    }
}
