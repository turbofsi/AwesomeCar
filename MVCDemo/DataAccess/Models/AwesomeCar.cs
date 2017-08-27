using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCDemo.DataAccess.Models
{
    public enum ProducerCountry
    {
        None,
        America,
        Japan,
        China,
        Italy,
        German,
        France
    } 
    public class AwesomeCar
    {
        [Key]
        public int CarId { get; set; }
        public string CarName { get; set; }
        public string BrandName { get; set; }
        public int MileAge { get; set; }
        public ProducerCountry producerCountry { get; set; }
    }
}
