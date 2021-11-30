using MediatR;
using Retailer.Demo.CustomerAccounts.Application.Queries.Responses;

namespace Retailer.Demo.CustomerAccounts.Application.Queries
{
    public class GetUserByIdQuery : IRequest<GetUserByIdQueryResponse>
    {
        public string Id { get; }

        public GetUserByIdQuery(string id)
        {
            Id = id;
        }
    }
}
