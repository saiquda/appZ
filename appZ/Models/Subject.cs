using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appZ.Models
{
    public class Subject
    {
        public int Id { get; set; }
        [Display(Name = "Субъект")]
        public string Name { get; set; }
        
        public List<City> Cities { get; set; }
        [Display(Name = "Страна")]
        public int CountryId { get; set; }
        [Display(Name = "Страна")]
        public Country Country { get; set; }
    }
}
