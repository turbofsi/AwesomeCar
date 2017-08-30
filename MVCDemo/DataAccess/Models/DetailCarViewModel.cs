using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCDemo.DataAccess.Models
{
    public class DetailCarViewModel
    {
        public string CarName { get; set; }
        public int Miliage { get; set; }
        public ProducerCountry ProducerCountry { get; set; }
    }
}
