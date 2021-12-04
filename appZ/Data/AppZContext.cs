using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appZ.Models
{
    public class AppZContext : DbContext
    {
        public DbSet<Country> Countries { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<City> Cities { get; set; }

        public AppZContext(DbContextOptions<AppZContext> options)
            : base(options)
        {
            
        }
    }
}
