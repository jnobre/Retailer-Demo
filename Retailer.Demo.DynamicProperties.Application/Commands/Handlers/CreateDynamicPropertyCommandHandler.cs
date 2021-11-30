using AutoMapper;
using MediatR;
using Retailer.Demo.DynamicProperties.Application.Commands.Responses;
using Retailer.Demo.DynamicProperties.Application.DTOs;
using Retailer.Demo.DynamicProperties.Domain.Repositories.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Retailer.Demo.DynamicProperties.Application.Commands.Handlers
{
    public class CreateDynamicPropertyCommandHandler : IRequestHandler<CreateDynamicPropertyCommand, CreateDynamicPropertyCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IDynamicPropertyRepository _dynamicPropertyRepository;

        public CreateDynamicPropertyCommandHandler(IMapper mapper, IDynamicPropertyRepository dynamicPropertyRepository)
        {
            _mapper = mapper;
            _dynamicPropertyRepository = dynamicPropertyRepository;
        }

        public async Task<CreateDynamicPropertyCommandResponse> Handle(CreateDynamicPropertyCommand request, CancellationToken cancellationToken)
        {
            var dynamicProperty = await _dynamicPropertyRepository.CreateAsync(new Domain.Entities.DynamicProperty
            {
                Name = request.Name,
                DisplayName = request.DisplayName,
                Required = request.Required,
                Searchable = request.Searchable,
                Scope = request.Scope,
                Type = request.Type,
                LocaleCode = request.LocaleCode,
                CreatedDate = DateTime.UtcNow,
                UpdatedDate = DateTime.UtcNow
            });

            var response = new CreateDynamicPropertyCommandResponse();
            response.AddResult(_mapper.Map(dynamicProperty, new DynamicPropertyDTO()));

            return response;
        }
    }
}