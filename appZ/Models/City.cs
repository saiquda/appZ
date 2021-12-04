using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appZ.Models
{
    public class City
    {
        public int Id { get; set; }

        [Display(Name = "Название")]
        public string Name { get; set; }
        
        public int SubjectId { get; set; }

        public Subject Subject { get; set; }
    }
}
