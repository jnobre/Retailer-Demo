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
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, UpdateUserCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public UpdateUserCommandHandler(IMapper mapper, IUserRepository userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<UpdateUserCommandResponse> Handle(UpdateUserCommand command, CancellationToken cancellationToken)
        {
            var user = await _userRepository.UpdateAsync(new User
            {
                Id = command.Id,
                UserName = command.Name,
                Age = command.Age
            });

            var response = new UpdateUserCommandResponse();
            response.AddResult(_mapper.Map(user, new UserDTO()));

            return response;
        }
    }
}
