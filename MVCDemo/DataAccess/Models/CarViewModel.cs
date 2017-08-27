using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCDemo.DataAccess.Models
{
    public class CarViewModel
    {
        public List<AwesomeCar> Cars { get; set; }
        public string CarName { get; set; }
        public string BrandName { get; set; }
        public ProducerCountry producerCountry { get; set; }
        public int MileAge { get; set; }
    }
}
