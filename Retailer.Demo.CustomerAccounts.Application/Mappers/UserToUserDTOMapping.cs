using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Retailer.Demo.CustomerAccounts.Application.DTOs;
using Retailer.Demo.CustomerAccounts.Domain.Entities;

namespace Retailer.Demo.CustomerAccounts.Application.Mappers
{
    public class UserToUserDTOMapping : Profile
    {
        public UserToUserDTOMapping()
        {
            CreateMap<User, UserDTO>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(x => x.UserName));
        }
    }
}
