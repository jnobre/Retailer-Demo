using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Retailer.Demo.CustomerAccounts.Application.DTOs;
using Retailer.Demo.CustomerAccounts.Application.Queries.Responses;
using Retailer.Demo.CustomerAccounts.Domain.Repositories.Interfaces;

namespace Retailer.Demo.CustomerAccounts.Application.Queries.Handlers
{
    public class GetUserByIdQueryRequestHandler : IRequestHandler<GetUserByIdQuery, GetUserByIdQueryResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public GetUserByIdQueryRequestHandler(IMapper mapper, IUserRepository userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<GetUserByIdQueryResponse> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetAsync(x => x.Id == request.Id);
            var response = new GetUserByIdQueryResponse();
            response.AddResult(_mapper.Map(user, new UserDTO()));

            return response;
        }
    }
}
