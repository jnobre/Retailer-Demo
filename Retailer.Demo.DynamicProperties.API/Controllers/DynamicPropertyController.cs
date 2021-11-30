using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Retailer.Demo.DynamicProperties.API.Requests;
using Retailer.Demo.DynamicProperties.Application.Commands;
using Retailer.Demo.DynamicProperties.Application.Commands.Responses;
using System.Threading.Tasks;

namespace Retailer.Demo.DynamicProperties.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DynamicPropertyController : ControllerBase
    {
        private readonly ILogger<DynamicPropertyController> _logger;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public DynamicPropertyController(ILogger<DynamicPropertyController> logger, IMediator mediator, IMapper mapper)
        {
            _logger = logger;
            _mediator = mediator;
            _mapper = mapper;
        }

        /// <summary>
        /// Create a new Dynamic Property
        /// </summary>
        /// <param name="request">Input Dynamic Property</param>
        /// <returns>The <see cref="DynamicProperty"/> if created.</returns>
        /// <response code="200">DynamicProperty created.</response>
        /// <response code ="400">Bad paramters.</response>
        [HttpPost]
        public async Task<CreateDynamicPropertyCommandResponse> Create([FromBody] CreateDynamicPropertyRequest request)
        {
            var command = _mapper.Map(request, new CreateDynamicPropertyCommand());
            return await _mediator.Send(command);
        }

    }
}
