using CasgemMicroservice.Services.Basket.Dtos;
using CasgemMicroservice.Shared.Dtos;
using System.Text.Json;

namespace CasgemMicroservice.Services.Basket.Services
{
    public class BasketService : IBasketService
    {
        private readonly RedisService redisService;

        public BasketService(RedisService redisService)
        {
            this.redisService = redisService;
        }

        public async Task<Response<bool>> Delete(string userId)
        {
            var status = await redisService.GetDb().KeyDeleteAsync(userId);
            return status ? Response<bool>.Success(204) : Response<bool>.Fail("Sepet Bulunamadı", 404);
        }

        public async Task<Response<BasketDto>> GetBasket(string userId)
        {
            var existBasket = await redisService.GetDb().StringGetAsync(userId);
            if (string.IsNullOrEmpty(existBasket))
            {
                return Response<BasketDto>.Fail("Sepet Bulunamadı", 404);
            }
            return Response<BasketDto>.Success(JsonSerializer.Deserialize<BasketDto>(existBasket), 200);
        }

        public async Task<Response<bool>> SaveOrUpdate(BasketDto dto)
        {
            var status = await redisService.GetDb().StringSetAsync(dto.UserID, JsonSerializer.Serialize(dto));
            return status ? Response<bool>.Success(204) : Response<bool>.Fail("Sepet Güncelleme Ya Da Ekleme Yapılamadı.", 500);
        }
    }
}
