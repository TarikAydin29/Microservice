using CasgemMicroservice.Services.Basket.Dtos;
using CasgemMicroservice.Services.Basket.Services;
using CasgemMicroservice.Shared.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CasgemMicroservice.Services.Basket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketsController : ControllerBase
    {
        private readonly IBasketService basketService;
        private readonly ISharedIdentityService sharedIdentityService;

        public BasketsController(IBasketService basketService, ISharedIdentityService sharedIdentityService)
        {
            this.basketService = basketService;
            this.sharedIdentityService = sharedIdentityService;
        }

        [HttpGet]
        public async Task<IActionResult> GetBasket()
        {
            return Ok(await basketService.GetBasket(sharedIdentityService.GetUserID));
        }
        [HttpPost]
        public async Task<IActionResult> SaveOrUpdateBasket(BasketDto dto)
        {
            dto.UserID = sharedIdentityService.GetUserID;
            var response = await basketService.SaveOrUpdate(dto);
            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteBasket()
        {
            return Ok(await basketService.Delete(sharedIdentityService.GetUserID));
        }
    }
}
