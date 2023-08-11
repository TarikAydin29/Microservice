using AutoMapper;
using CasgemMicroservice.Services.Discount.Context;
using CasgemMicroservice.Services.Discount.Dtos;
using CasgemMicroservice.Services.Discount.Models;
using CasgemMicroservice.Shared.Dtos;
using Microsoft.EntityFrameworkCore;

namespace CasgemMicroservice.Services.Discount.Services
{
    public class DiscountService : IDiscountService
    {
        private readonly DapperContext context;
        private readonly IMapper mapper;

        public DiscountService(DapperContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<Response<NoContent>> CreateDiscountCouponAsync(CreateDiscountDto dto)
        {
            var value = mapper.Map<DiscountCoupons>(dto);
            await context.DiscountCouponses.AddAsync(value);
            await context.SaveChangesAsync();
            return Response<NoContent>.Success(201);
        }

        public async Task<Response<NoContent>> DeleteDiscountCouponAsync(int id)
        {
            var result = await context.DiscountCouponses.FindAsync(id);
            if (result == null)
            {
                return Response<NoContent>.Fail("Güncellenecek Kupon Bulunamadı.", 404);
            }
            context.DiscountCouponses.Remove(result);
            await context.SaveChangesAsync();
            return Response<NoContent>.Success(204);
        }

        public async Task<Response<List<ResultDiscountDto>>> GetAllDiscountCouponsAsync()
        {
            var values = await context.DiscountCouponses.ToListAsync();
            return Response<List<ResultDiscountDto>>.Success(mapper.Map<List<ResultDiscountDto>>(values), 200);
        }

        public async Task<Response<ResultDiscountDto>> GetByIdDiscountCouponAsync(int id)
        {
            var result = await context.DiscountCouponses.FindAsync(id);
            return Response<ResultDiscountDto>.Success(mapper.Map<ResultDiscountDto>(result), 200);
        }

        public async Task<Response<NoContent>> UpdateDiscountCouponAsync(UpdateDiscountDto dto)
        {
            var existingResponse = await context.DiscountCouponses.FindAsync(dto.DiscountCouponsID);
            if (existingResponse == null)
            {
                return Response<NoContent>.Fail("Güncellenecek Kupon Bulunamadı.", 404);
            }
            mapper.Map(dto, existingResponse);
            context.DiscountCouponses.Update(existingResponse);
            await context.SaveChangesAsync();
            return Response<NoContent>.Success(204);
        }
    }
}
