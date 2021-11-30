using AutoMapper;
using Retailer.Demo.DynamicProperties.API.Requests;
using Retailer.Demo.DynamicProperties.Application.Commands;

namespace Retailer.Demo.DynamicProperties.API.Mappers
{
    public class AutoMappings : Profile
    {
        public AutoMappings()
        {
            CreateMap<CreateDynamicPropertyRequest,CreateDynamicPropertyCommand>();
        }
    }
}
