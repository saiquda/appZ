using appZ.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appZ.Data
{
    public static class DbInitializer
    {
        public static void Initialize(AppZContext context)
        {
            context.Database.EnsureCreated();
            if (!context.Countries.Any())
            {
                var countries = new Country[] 
                {
                    new Country {Name = "Россия"},
                    new Country {Name = "Казахстан"},
                    new Country {Name = "Беларусь"}
                };
                foreach (Country s in countries){
                    context.Countries.Add(s);
                }
                context.SaveChanges();

                var subjects = new Subject[]
                {
                    new Subject {Name = "Северная Осетия", Country = countries[0]},
                    new Subject {Name = "Московская область", CountryId = countries[0].Id},
                    new Subject {Name = "Чеченская Республика", CountryId = countries[0].Id},
                };
                foreach (Subject s in subjects)
                {
                    context.Subjects.Add(s);
                }
                context.SaveChanges();
                var cities = new City[]
                {
                    new City{Name = "Владикавказ",Subject = subjects[0]},
                    new City{Name = "Москва",SubjectId = subjects[1].Id},
                    new City{Name = "Грозный",SubjectId = subjects[2].Id},
                };
                foreach (City s in cities)
                {
                    context.Cities.Add(s);
                }
                context.SaveChanges();
            }
        }
    }
}
