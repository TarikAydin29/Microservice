using CasgemMicroservice.Services.Order.Core.Application.Features.CQRS.Commands;
using CasgemMicroservice.Services.Order.Core.Application.Interfaces;
using CasgemMicroservice.Services.Order.Core.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasgemMicroservice.Services.Order.Core.Application.Features.CQRS.Handlers
{
    public class UpdateAddressCommandHandler : IRequestHandler<UpdateAddressCommandRequest>
    {
        private readonly IRepository<Address> repository;

        public UpdateAddressCommandHandler(IRepository<Address> repository)
        {
            this.repository = repository;
        }
        public async Task Handle(UpdateAddressCommandRequest request, CancellationToken cancellationToken)
        {
            var value = await repository.GetByIdAsync(request.AddressID);
            value.UserID = request.UserID;
            value.City = request.City;
            value.District = request.District;
            value.Detail = request.Detail;
            await repository.UpdateAsync(value);
        }
    }
}
