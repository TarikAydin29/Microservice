using CasgemMicroservice.Services.Order.Core.Application.Features.CQRS.Commands;
using CasgemMicroservice.Services.Order.Core.Application.Features.CQRS.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CasgemMicroservice.Services.Order.Presentation.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailController : ControllerBase
    {
        private readonly IMediator mediator;

        public OrderDetailController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> OrderDetailList()
        {
            var values = await mediator.Send(new GetAllOrderDetailQueryRequest());
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> OrderDetailGetById(int id)
        {
            var value = mediator.Send(new GetByIdOrderDetailQueryRequest(id));
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> OrderDetailCreate(CreateOrderDetailCommandRequest request)
        {
            await mediator.Send(request);
            return Ok("Sipariş Detayı Eklendi.");
        }
        [HttpPut]
        public async Task<IActionResult> OrderDetailUpdate(UpdateOrderDetailCommandRequest request)
        {
            await mediator.Send(request);
            return Ok("Sipariş Detayı Güncellendi.");
        }
        [HttpDelete]
        public async Task<IActionResult> OrderDetailDelete(int id)
        {
            await mediator.Send(new RemoveOrderDetailCommandRequest(id));
            return Ok("Sipariş Detayı Silindi.");
        }
    }
}
