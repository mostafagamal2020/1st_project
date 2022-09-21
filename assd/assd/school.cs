using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace assd
{
    public class school:DbContext
    {
        public DbSet<student> Students { get; set; }

        public DbSet<subject> Subjects { get; set; }

        public DbSet<regform> RegForms { get; set; }

        public DbSet<regformitem> RegFormItems { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server = DESKTOP-7GRAGVK;
Database =school ;
trusted_connection = true;");
        }
    }
}
