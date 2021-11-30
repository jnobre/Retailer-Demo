using MediatR;
using Retailer.Demo.CustomerAccounts.Application.Queries.Responses;

namespace Retailer.Demo.CustomerAccounts.Application.Queries
{
    public class GetAllUserQuery : IRequest<GetAllUserQueryResponse>
    { }
}
