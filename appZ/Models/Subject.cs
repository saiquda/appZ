using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appZ.Models
{
    public class Subject
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public List<City> Cities { get; set; }

        public int CountryId { get; set; }

        public Country Country { get; set; }
    }
}
