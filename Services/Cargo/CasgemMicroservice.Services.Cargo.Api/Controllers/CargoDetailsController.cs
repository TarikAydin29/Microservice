using CasgemMicroservice.Services.Cargo.BLL.Abstract;
using CasgemMicroservice.Services.Cargo.Entity.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CasgemMicroservice.Services.Cargo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CargoDetailsController : ControllerBase
    {
        private readonly ICargoDetailService cargoDetailService;

        public CargoDetailsController(ICargoDetailService cargoDetailService)
        {
            this.cargoDetailService = cargoDetailService;
        }
        [HttpGet]
        public IActionResult CargoDetailList()
        {
            var values = cargoDetailService.TGetAll();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult GetCargoDetailById(int id)
        {
            var value = cargoDetailService.TGetById(id);
            return Ok(value);
        }
        [HttpPost]
        public IActionResult CreateCargoDetail(CargoDetail detail)
        {
            cargoDetailService.TInsert(detail);
            return Ok("Kargo Detayı Eklendi");
        }
        [HttpPut]
        public IActionResult UpdateCargoDetail(CargoDetail detail)
        {
            cargoDetailService.TUpdate(detail);
            return Ok("Kargo Detayı Güncellendi");
        }
        [HttpDelete]
        public IActionResult DeleteCargoDetail(CargoDetail detail)
        {
            cargoDetailService.TDelete(detail);
            return Ok("Kargo Detayı Silindi");
        }
    }
}
