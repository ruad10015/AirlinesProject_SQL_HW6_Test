using AirlinesProject_SQL_HW6.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlinesProject_SQL_HW6.DataAccess
{
    public class MyContext : DbContext
    {
        public MyContext()
            :base("AirlinesDb") { }

        public DbSet<Airplane> Airplanes { get; set; }
        public DbSet<Cities> Cities { get; set; }
        public DbSet<Pilot> Pilots { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
    }
}
