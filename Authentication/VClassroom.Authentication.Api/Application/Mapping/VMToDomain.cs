using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VClassroom.Authentication.Api.Application.Models;
using VClassroom.Authentication.Api.Domain.Models;

namespace VClassroom.Authentication.Api.Mapping
{
    public class VMToDomain : Profile
    {
        public VMToDomain()
        {
            CreateMap<RegisterVm, ApplicationUser>();
        }
    }
}
