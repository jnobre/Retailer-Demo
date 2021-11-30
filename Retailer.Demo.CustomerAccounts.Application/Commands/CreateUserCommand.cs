using MediatR;
using Retailer.Demo.CustomerAccounts.Application.Commands.Responses;

namespace Retailer.Demo.CustomerAccounts.Application.Commands
{
    public class CreateUserCommand : IRequest<CreateUserCommandResponse>
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
