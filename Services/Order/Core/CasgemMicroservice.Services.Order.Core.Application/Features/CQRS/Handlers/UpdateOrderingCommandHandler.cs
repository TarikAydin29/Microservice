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
    public class UpdateOrderingCommandHandler : IRequestHandler<UpdateOrderingCommandRequest>
    {
        private readonly IRepository<Ordering> repository;

        public UpdateOrderingCommandHandler(IRepository<Ordering> repository)
        {
            this.repository = repository;
        }
        public async Task Handle(UpdateOrderingCommandRequest request, CancellationToken cancellationToken)
        {
            var value = await repository.GetByIdAsync(request.OrderingID);
            value.UserID = request.UserID;
            value.TotalPrice = request.TotalPrice;
            value.OrderDate = request.OrderDate;
            await repository.UpdateAsync(value);
        }
    }
    
}
