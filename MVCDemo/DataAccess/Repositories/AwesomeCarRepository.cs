using MVCDemo.DataAccess.Entities;
using MVCDemo.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCDemo.DataAccess.Repositories
{
    public interface IAwesomeCarRepository
    {
        AwesomeCar GetCarById(int id);
        void Commit();
    }

    public class AwesomeCarRepository : IAwesomeCarRepository
    {
        private AwesomeCarDbContext _context;

        public AwesomeCarRepository(AwesomeCarDbContext context)
        {
            _context = context;
        }

        public AwesomeCar GetCarById(int id)
        {
            return _context.AwesomeCars.FirstOrDefault(c => c.CarId == id);
        }

        public void Commit()
        {
            _context.SaveChanges();
        }
    }
}
