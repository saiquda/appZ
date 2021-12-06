using appZ.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appZ.ViewModel
{
    public class CountriesSubjectsCitiesViewModel
    {
        public IEnumerable<Subject> Subjects;
        public IEnumerable<City> Cities;
        public IEnumerable<Country> Countries;
    }
}
