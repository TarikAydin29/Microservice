using CasgemMicroservice.Services.Cargo.Entity.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasgemMicroservice.Services.Cargo.DAL.Concrete
{
    public class CargoContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=localhost,1433;Database=CargoCasgemDb;User=sa;Password=123456aA#");
        }
        public DbSet<CargoDetail> CargoDetails { get; set; }
        public DbSet<CargoState> CargoStates { get; set; }
    }
}
