using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Retailer.Demo.CustomerAccounts.API.Requests;
using Retailer.Demo.CustomerAccounts.Application.Commands;
using Retailer.Demo.CustomerAccounts.Application.Commands.Responses;
using Retailer.Demo.CustomerAccounts.Application.Queries;
using Retailer.Demo.CustomerAccounts.Application.Queries.Responses;


namespace Retailer.Demo.CustomerAccounts.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestMongoController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public TestMongoController(ILogger<WeatherForecastController> logger, IMediator mediator, IMapper mapper)
        {
            _logger = logger;
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("")]
        public async Task<GetAllUserQueryResponse> GetAll()
        {
            var query = new GetAllUserQuery();
            return await _mediator.Send(query);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<GetUserByIdQueryResponse> GetByName(string id)
        {
            var query = new GetUserByIdQuery(id);
            return await _mediator.Send(query);
        }

        [HttpPost]
        [Route("")]
        public async Task<CreateUserCommandResponse> Create([FromBody] CreateUserRequest request)
        {
            var command = _mapper.Map(request, new CreateUserCommand());
            return await _mediator.Send(command);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<UpdateUserCommandResponse> Update([FromRoute]string id, [FromBody] UpdateUserRequest request)
        {
            var command = _mapper.Map(request, new UpdateUserCommand());
            command.Id = id;
            return await _mediator.Send(command);
        }
    }
}
