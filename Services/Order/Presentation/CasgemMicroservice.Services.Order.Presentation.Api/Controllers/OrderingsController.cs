using CasgemMicroservice.Services.Order.Core.Application.Features.CQRS.Commands;
using CasgemMicroservice.Services.Order.Core.Application.Features.CQRS.Queries;
using CasgemMicroservice.Shared.Services;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;

namespace CasgemMicroservice.Services.Order.Presentation.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OrderingsController : ControllerBase
    {
        private readonly IMediator mediator;
        private readonly ISharedIdentityService sharedIdentityService;

        public OrderingsController(IMediator mediator, ISharedIdentityService sharedIdentityService)
        {
            this.mediator = mediator;
            this.sharedIdentityService = sharedIdentityService;
        }
        [HttpGet]
        public async Task<IActionResult> OrderingList()
        {
            var values = await mediator.Send(new GetAllOrderingQueryRequest());
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> OrderingGetById(int id)
        {
            var value = mediator.Send(new GetByIdOrderingQueryRequest(id));
            return Ok(value);
        }

        [HttpGet]
        public async Task<IActionResult> OrderingGetByUserId()
        {
            var value = await mediator.Send(new GetByUserIdOrderingQueryRequest
            {
                Id = sharedIdentityService.GetUserID
            });
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> OrderingCreate(CreateOrderingCommandRequest request)
        {
            await mediator.Send(request);
            return Ok("Sipariş Eklendi.");
        }
        [HttpPut]
        public async Task<IActionResult> OrderingUpdate(UpdateOrderingCommandRequest request)
        {
            await mediator.Send(request);
            return Ok("Sipariş Güncellendi.");
        }
        [HttpDelete]
        public async Task<IActionResult> OrderDetailDelete(int id)
        {
            await mediator.Send(new RemoveOrderingCommandRequest(id));
            return Ok("Sipariş Silindi.");
        }


    }
}
