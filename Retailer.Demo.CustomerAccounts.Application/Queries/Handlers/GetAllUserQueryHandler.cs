using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Retailer.Demo.CustomerAccounts.Application.DTOs;
using Retailer.Demo.CustomerAccounts.Application.Queries.Responses;
using Retailer.Demo.CustomerAccounts.Domain.Repositories.Interfaces;

namespace Retailer.Demo.CustomerAccounts.Application.Queries.Handlers
{
    public class GetAllUserQueryRequestHandler : IRequestHandler<GetAllUserQuery, GetAllUserQueryResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public GetAllUserQueryRequestHandler(IMapper mapper, IUserRepository userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<GetAllUserQueryResponse> Handle(GetAllUserQuery request, CancellationToken cancellationToken)
        {
            var users = await _userRepository.GetAllAsync();
            var response = new GetAllUserQueryResponse();
            response.AddResult(users.Select(x => _mapper.Map(x, new UserDTO())).ToList().AsReadOnly());
            
            return response;
        }
    }
}
