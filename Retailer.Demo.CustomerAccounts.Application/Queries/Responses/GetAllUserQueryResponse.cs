using System.Collections.Generic;
using Retailer.Demo.CustomerAccounts.Application.DTOs;

namespace Retailer.Demo.CustomerAccounts.Application.Queries.Responses
{
    public class GetAllUserQueryResponse : BaseResponse<IReadOnlyCollection<UserDTO>>
    { }
}
