using MVCDemo.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCDemo.DataAccess.Repositories
{
    public interface IAwesomeCarQueryHandler
    {
        IEnumerable<AwesomeCar> GetAwesomeCars();
        void Add(AwesomeCar car);
        AwesomeCar GetAwesomeCarById(int id);
    }
    public class AwesomeCarQueryHandler : IAwesomeCarQueryHandler
    {
        private static List<AwesomeCar> _cars;
        public AwesomeCarQueryHandler()
        {
            _cars = new List<AwesomeCar> {
                new AwesomeCar { CarId = 1, BrandName = "Lexus", CarName = "RX350", MileAge = 28000, producerCountry = ProducerCountry.America },
                new AwesomeCar { CarId = 2, BrandName = "Mazda", CarName = "Mazda3 GS", MileAge = 18000, producerCountry = ProducerCountry.Japan }
            };

        }

        public void Add(AwesomeCar car)
        {
            int id = _cars.OrderByDescending(c => c.CarId).First().CarId++;
            car.CarId = id;
            car.CarName = car.CarName;
            car.BrandName = car.BrandName;
            car.producerCountry = car.producerCountry;
            _cars.Add(car);
        }

        public AwesomeCar GetAwesomeCarById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<AwesomeCar> GetAwesomeCars()
        {
            throw new NotImplementedException();
        }
    }
}
