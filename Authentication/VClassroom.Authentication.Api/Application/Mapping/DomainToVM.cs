using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VClassroom.Authentication.Api.Application.Models;
using VClassroom.Authentication.Api.Domain.Models;

namespace VClassroom.Authentication.Api.Mapping
{
    public class DomainToVM : Profile
    {
        public DomainToVM()
        {
            CreateMap<ApplicationUser, RegisterVm>();
            CreateMap<InstructorProfileVm, InstructorProfile>();
        }
    }
}
