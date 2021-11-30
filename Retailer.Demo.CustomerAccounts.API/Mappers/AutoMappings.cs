using AutoMapper;
using Retailer.Demo.CustomerAccounts.API.Requests;
using Retailer.Demo.CustomerAccounts.Application.Commands;

namespace Retailer.Demo.CustomerAccounts.API.Mappers
{
    public class AutoMappings : Profile
    {
        public AutoMappings()
        {
            CreateMap<CreateUserRequest, CreateUserCommand>();
            CreateMap<UpdateUserRequest, UpdateUserCommand>();
        }
    }
}
