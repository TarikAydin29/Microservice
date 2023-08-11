using CasgemMicroservice.Services.Discount.Dtos;
using CasgemMicroservice.Services.Discount.Models;
using CasgemMicroservice.Shared.Dtos;

namespace CasgemMicroservice.Services.Discount.Services
{
    public interface IDiscountService
    {
        Task<Response<List<ResultDiscountDto>>> GetAllDiscountCouponsAsync();
        Task<Response<ResultDiscountDto>> GetByIdDiscountCouponAsync(int id);
        Task<Response<NoContent>> CreateDiscountCouponAsync(CreateDiscountDto dto);
        Task<Response<NoContent>> UpdateDiscountCouponAsync(UpdateDiscountDto dto);
        Task<Response<NoContent>> DeleteDiscountCouponAsync(int id);
    }
}
