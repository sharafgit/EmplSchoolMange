using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmplSchoolMange.DAL.Entities;

namespace EmplSchoolMange.DAL.Database
{
    public class DbContainer:DbContext
    {
        //OnConfiguring***optionsBuilder //*******ConnectionString********

        public DbContainer(DbContextOptions<DbContainer> opts) : base(opts)
        {

        }
        public DbSet<Department> Department { get; set; }
        public DbSet<Employee> Employee { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("server=. ; database=SMangement; integrated security = true");
        //}
    }
}
