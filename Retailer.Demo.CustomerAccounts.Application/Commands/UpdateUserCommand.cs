using MediatR;
using Retailer.Demo.CustomerAccounts.Application.Commands.Responses;

namespace Retailer.Demo.CustomerAccounts.Application.Commands
{
    public class UpdateUserCommand : IRequest<UpdateUserCommandResponse>
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
