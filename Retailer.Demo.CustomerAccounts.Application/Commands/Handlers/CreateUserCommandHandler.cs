using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Retailer.Demo.CustomerAccounts.Application.Commands.Responses;
using Retailer.Demo.CustomerAccounts.Application.DTOs;
using Retailer.Demo.CustomerAccounts.Domain.Entities;
using Retailer.Demo.CustomerAccounts.Domain.Repositories.Interfaces;

namespace Retailer.Demo.CustomerAccounts.Application.Commands.Handlers
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, CreateUserCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public CreateUserCommandHandler(IMapper mapper, IUserRepository userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<CreateUserCommandResponse> Handle(CreateUserCommand command, CancellationToken cancellationToken)
        {
            var user = await _userRepository.CreateAsync(new User
            {
                UserName = command.Name,
                Age = command.Age
            });

            var response = new CreateUserCommandResponse();
            response.AddResult(_mapper.Map(user, new UserDTO()));

            return response;
        }
    }
}
