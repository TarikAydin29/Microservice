using CasgemMicroservice.Services.Cargo.DAL.Abstract;
using CasgemMicroservice.Services.Cargo.DAL.Concrete;
using CasgemMicroservice.Services.Cargo.DAL.Repository;
using CasgemMicroservice.Services.Cargo.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasgemMicroservice.Services.Cargo.DAL.EntityFramework
{
    public class EFCargoDetailDAL : GenericRepository<CargoDetail>, ICargoDetailDAL
    {
        public EFCargoDetailDAL(CargoContext context) : base(context)
        {
        }
    }
}
