using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using VClassroom.CourseManagement.Domain.Entities;

namespace VClassroom.CourseManagement.Application.Common.Mappings
{
    class SessionMapping : Profile
    {
        public SessionMapping()
        {
            CreateMap<SessionDTO, Session>();
            CreateMap<Session, SessionDTO>();
        }
    }
}
