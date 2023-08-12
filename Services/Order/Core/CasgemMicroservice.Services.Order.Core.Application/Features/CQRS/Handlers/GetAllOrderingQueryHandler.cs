using AutoMapper;
using CasgemMicroservice.Services.Order.Core.Application.Dtos.OrderDtos;
using CasgemMicroservice.Services.Order.Core.Application.Features.CQRS.Queries;
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
    public class GetAllOrderingQueryHandler : IRequestHandler<GetAllOrderingQueryRequest, List<ResultOrderingDto>>
    {
        private readonly IRepository<Ordering> repository;
        private readonly IMapper mapper;

        public GetAllOrderingQueryHandler(IRepository<Ordering> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public async Task<List<ResultOrderingDto>> Handle(GetAllOrderingQueryRequest request, CancellationToken cancellationToken)
        {
            var values = await repository.GetAllAsync();
            return mapper.Map<List<ResultOrderingDto>>(values);
        }
    }
}
