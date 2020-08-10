using DataAccess.ModelRepresentation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Context
{
    public class DailyTaskDBContext : DbContext
    {
        public DbSet<DailyTaskRepresentation> DailyTaskTable {get; set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer
                (@"Server=DESKTOP-NHJRKUO;Initial Catalog=DailyTaskDB;Integrated Security=True;");
                
        }
    }
}
