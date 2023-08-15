using CasgemMicroservice.Services.Order.Core.Application.Features.CQRS.Commands;
using CasgemMicroservice.Services.Order.Core.Application.Features.CQRS.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;

namespace CasgemMicroservice.Services.Order.Presentation.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressesController : ControllerBase
    {
        private readonly IMediator mediator;

        public AddressesController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> AddressList()
        {
            var values = await mediator.Send(new GetAllAddressQueryRequest());
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> AddressGetById(int id)
        {
            var value = await mediator.Send(new GetByIdAddressQueryRequest(id));
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> AddressCreate(CreateAddressCommandRequest request)
        {
            await mediator.Send(request);
            return Ok("Adres Eklendi.");
        }
        [HttpPut]
        public async Task<IActionResult> AddressUpdate(UpdateAddressCommandRequest request)
        {
            await mediator.Send(request);
            return Ok("Adres Güncellendi.");
        }
        [HttpDelete]
        public async Task<IActionResult> AddressDelete(int id)
        {
            await mediator.Send(new RemoveAddressCommandRequest(id));
            return Ok("Adres Silindi.");
        }
    }
}
