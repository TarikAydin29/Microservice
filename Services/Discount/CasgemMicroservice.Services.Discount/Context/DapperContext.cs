using CasgemMicroservice.Services.Discount.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace CasgemMicroservice.Services.Discount.Context
{
    public class DapperContext : DbContext
    {
        private readonly IConfiguration configuration;
        private readonly string connectionString;

        public DapperContext(IConfiguration configuration)
        {
            this.configuration = configuration;
            connectionString = configuration.GetConnectionString("DefaultConnection");
        }
        //public DapperContext(DbContextOptions<DapperContext> options) : base(options)
        //{

        //}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=localhost,1433;Database=CasgemDiscountDb;User=sa;Password=123456aA#");
        }

        public DbSet<DiscountCoupons> DiscountCouponses { get; set; }

        public IDbConnection CreateConnection() => new SqlConnection(connectionString);
    }
}
