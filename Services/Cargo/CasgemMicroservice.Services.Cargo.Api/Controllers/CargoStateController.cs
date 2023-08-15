using CasgemMicroservice.Services.Cargo.BLL.Abstract;
using CasgemMicroservice.Services.Cargo.Entity.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CasgemMicroservice.Services.Cargo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CargoStateController : ControllerBase
    {
        private readonly ICargoStateService cargoStateService;

        public CargoStateController(ICargoStateService cargoStateService)
        {
            this.cargoStateService = cargoStateService;
        }
        [HttpGet]
        public IActionResult CargoStateList()
        {
            var values = cargoStateService.TGetAll();

            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult GetCargoStateById(int id)
        {
            var value = cargoStateService.TGetById(id);
            return Ok(value);
        }
        [HttpPost]
        public IActionResult CreateCargoState(CargoState state)
        {
            cargoStateService.TInsert(state);
            return Ok("Kargo Durumu Eklendi");
        }
        [HttpPut]
        public IActionResult UpdateCargoState(CargoState state)
        {
            cargoStateService.TUpdate(state);
            return Ok("Kargo Durumu Güncellendi");
        }
        [HttpDelete]
        public IActionResult DeleteCargoState(CargoState state)
        {
            cargoStateService.TDelete(state);
            return Ok("Kargo Durumu Silindi");
        }
    }
}
