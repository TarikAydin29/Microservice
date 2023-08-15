using CasgemMicroservice.Services.Cargo.BLL.Abstract;
using CasgemMicroservice.Services.Cargo.DAL.Abstract;
using CasgemMicroservice.Services.Cargo.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasgemMicroservice.Services.Cargo.BLL.Concrete
{
    public class CargoDetailManager : ICargoDetailService
    {
        private readonly ICargoDetailDAL cargoDetailDAL;

        public CargoDetailManager(ICargoDetailDAL cargoDetailDAL)
        {
            this.cargoDetailDAL = cargoDetailDAL;
        }
        public void TDelete(CargoDetail t)
        {
            cargoDetailDAL.Delete(t);
        }

        public List<CargoDetail> TGetAll()
        {
            return cargoDetailDAL.GetAll();
        }

        public CargoDetail TGetById(int id)
        {
            return cargoDetailDAL.GetById(id);
        }

        public void TInsert(CargoDetail t)
        {
            cargoDetailDAL.Insert(t);
        }

        public void TUpdate(CargoDetail t)
        {
            cargoDetailDAL.Update(t);
        }
    }
}
