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
    public class CargoStateManager : ICargoStateService
    {
        private readonly ICargoStateDAL cargoStateDAL;

        public CargoStateManager(ICargoStateDAL cargoStateDAL)
        {
            this.cargoStateDAL = cargoStateDAL;
        }
        public void TDelete(CargoState t)
        {
            cargoStateDAL.Delete(t);
        }

        public List<CargoState> TGetAll()
        {
            return cargoStateDAL.GetAll();
        }

        public CargoState TGetById(int id)
        {
            return cargoStateDAL.GetById(id);
        }

        public void TInsert(CargoState t)
        {
            cargoStateDAL.Insert(t);
        }

        public void TUpdate(CargoState t)
        {
            cargoStateDAL.Update(t);
        }
    }
}
