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
                    new Subject {Name = "Северная Осетия", CountryId = countries[0].Id},
                    new Subject {Name = "Московская область", CountryId = countries[0].Id},
                    new Subject {Name = "Чеченская Республика", CountryId = countries[0].Id},
                    new Subject {Name = "Акмолинская область", CountryId = countries[1].Id},
                    new Subject {Name = "Актюбинская область", CountryId = countries[1].Id},
                    new Subject {Name = "Алматинская область", CountryId = countries[1].Id},
                    new Subject {Name = "Брестская область", CountryId = countries[2].Id},
                    new Subject {Name = "Витебская область", CountryId = countries[2].Id},
                    new Subject {Name = "Гомельская область", CountryId = countries[2].Id}
                };
                foreach (Subject s in subjects)
                {
                    context.Subjects.Add(s);
                }
                context.SaveChanges();
                var cities = new City[]
                {
                    new City{Name = "Владикавказ",SubjectId = subjects[0].Id},
                    new City{Name = "Моздок",SubjectId = subjects[0].Id},
                    new City{Name = "Беслан",SubjectId = subjects[0].Id},
                    new City{Name = "Москва",SubjectId = subjects[1].Id},
                    new City{Name = "Балашиха",SubjectId = subjects[1].Id},
                    new City{Name = "Подольск",SubjectId = subjects[1].Id},
                    new City{Name = "Грозный",SubjectId = subjects[2].Id},
                    new City{Name = "Гудермес",SubjectId = subjects[2].Id},
                    new City{Name = "Шали",SubjectId = subjects[2].Id},
                    new City{Name = "Кокшетау",SubjectId = subjects[3].Id},
                    new City{Name = "Степногорск",SubjectId = subjects[3].Id},
                    new City{Name = "Щучинск",SubjectId = subjects[3].Id},
                    new City{Name = "Актобе",SubjectId = subjects[4].Id},
                    new City{Name = "Кандыагаш",SubjectId = subjects[4].Id},
                    new City{Name = "Темир",SubjectId = subjects[4].Id},
                    new City{Name = "Капчагай",SubjectId = subjects[5].Id},
                    new City{Name = "Талдыкорган",SubjectId = subjects[5].Id},
                    new City{Name = "Текели",SubjectId = subjects[5].Id},
                    new City{Name = "Барановичи",SubjectId = subjects[6].Id},
                    new City{Name = "Брест",SubjectId = subjects[6].Id},
                    new City{Name = "Пинск ",SubjectId = subjects[6].Id},
                    new City{Name = "Витебск ",SubjectId = subjects[7].Id},
                    new City{Name = "Новополоцк ",SubjectId = subjects[7].Id},
                    new City{Name = "Городок ",SubjectId = subjects[7].Id},
                    new City{Name = "Гомель",SubjectId = subjects[8].Id},
                    new City{Name = "Ветка",SubjectId = subjects[8].Id},
                    new City{Name = "Добруш",SubjectId = subjects[8].Id},
                };
                foreach (City s in cities)
                {
                    context.Cities.Add(s);
                }
                context.SaveChanges();
                var users = new User[]
                {
                    new User{Email = "admin@boba.ru", Password = "Qwe123."}
                };
                foreach (User s in users)
                {
                    context.Users.Add(s);
                }
                context.SaveChanges();
            }
        }
    }
}
