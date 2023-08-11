using AutoMapper;
using CasgemMicroservice.Services.Discount.Dtos;
using CasgemMicroservice.Services.Discount.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CasgemMicroservice.Services.Discount.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountCouponsController : ControllerBase
    {
        private readonly IDiscountService discountService;


        public DiscountCouponsController(IDiscountService discountService)
        {
            this.discountService = discountService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllDiscountCoupons()
        {
            var values = await discountService.GetAllDiscountCouponsAsync();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdDiscountCoupon(int id)
        {
            var value = await discountService.GetByIdDiscountCouponAsync(id);
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreateDiscountCoupons(CreateDiscountDto dto)
        {
            await discountService.CreateDiscountCouponAsync(dto);
            return Ok("Kupon Başarıyla Oluşturuldu.");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateDiscountCoupons(UpdateDiscountDto dto)
        {
            await discountService.UpdateDiscountCouponAsync(dto);
            return Ok("Kupon Başarıyla Güncellendi.");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDiscountCoupons(int id)
        {
            await discountService.DeleteDiscountCouponAsync(id);
            return Ok("Kupon Başarıyla Silindi.");
        }
    }
}
