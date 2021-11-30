using AutoMapper;
using Retailer.Demo.DynamicProperties.Application.DTOs;
using Retailer.Demo.DynamicProperties.Domain.Entities;

namespace Retailer.Demo.DynamicProperties.Application.Mappers
{
    public class DynamicPropertyToDynamicPropertyDTO : Profile
    {
        public DynamicPropertyToDynamicPropertyDTO()
        {
            CreateMap<DynamicProperty, DynamicPropertyDTO>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(x => x.Name));
        }
    }
}
