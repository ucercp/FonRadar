using FonRadar.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FonRadar.DataAccess
{
    public class FonRadarContext: DbContext
    {
       
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseNpgsql("Host=localhost;Port=6432;Database=FonRadarDb;Username=postgres;Password=1234");

        }
        public DbSet<Invoice> Invoices { get; set; }
    }
}
