using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasgemMicroservice.Services.Cargo.Entity.Entities
{
    public class CargoState
    {
        public int CargoStateId { get; set; }
        public string Description { get; set; }


        public List<CargoDetail> CargoDetails { get; set; }
    }
}
